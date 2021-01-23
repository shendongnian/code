		public static void Main(string[] args)
		{
			Console.WriteLine("On the bottom line enter the command \"START\" followed by a space and a number representing on how many hours to check for new posts. You can always stop the execution with Ctrl+C \r\n \r\nExample : START 6");
			
			if(!ParseCMD(readKeey()))
			{
				ParseCMD(readKeey());
			}
			
		}private static string readKeey()
		{
			ConsoleKeyInfo cki;
			Console.TreatControlCAsInput = true;
			string temp="";
			do
			{
				cki = Console.ReadKey();
				temp=temp+cki.KeyChar;
				
			} while (cki.Key != ConsoleKey.Enter);
			return temp;
		}
		
		private static bool ParseCMD(string text)
		{
			try{
				string cmd = text;
				string[] commands = cmd.Trim().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
				int delay = 0;
				if (commands[0].ToLower() == "start" && int.TryParse(commands[1],out delay))
				{
					Console.WriteLine("Right command you enter:" + commands[0] + commands[1]);
					return true;
				}
				else
				{
					Console.WriteLine("Wrong command");
					
					return false;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("ex.Message:"+ex.Message);
				return false;
			}
		}
	}}
