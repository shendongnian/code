    	using System;
		using SignalR.Client.Hubs;
		namespace SignalRConsoleApp
		{
			internal class Program
			{
				private static void Main(string[] args)
				{
					//Set connection
					var connection = new HubConnection("http://127.0.0.1:8088/");
					//Make proxy to hub based on hub name on server
					var myHub = connection.CreateProxy("CustomHub");
					//Start connection
					connection.Start().ContinueWith(task =>
														{
															if (task.IsFaulted)
															{
																Console.WriteLine("There was an error opening the connection:{0}",
																				  task.Exception.GetBaseException());
															}
															else
															{
																Console.WriteLine("Connected");
															}
														}).Wait();
					myHub.Invoke<string>("Send", "HELLO World ").ContinueWith(task =>
																		{
																			if (task.IsFaulted)
																			{
																				Console.WriteLine("There was an error calling send: {0}",
																								  task.Exception.GetBaseException());
																			}
																			else
																			{
																				Console.WriteLine(task.Result);
																			}
																		});
					myHub.On<string>("addMessage", param =>
													{
														Console.WriteLine(param);
													});
					myHub.Invoke<string>("DoSomething", "I'm doing something!!!").Wait();
					connection.Stop();
					Console.Read();
				}
			}
		}
