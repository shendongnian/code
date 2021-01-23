	class MainClass {
		static void pausableFunction() {
			Console.WriteLine("* Waiting...");
		
			Event.Wait();
		
			Console.WriteLine("* Doing stuff.");
			Thread.Sleep(1000);
		
			Event.Wait();
		
			Console.WriteLine("* Finished!");
			
			Event.End();
		}
		
		static void anotherFunction(int foo) {
			Console.WriteLine("* Wanna know the value of a number?");
			
			Event.Wait();
			
			Console.WriteLine("* I'll tell you. It's {0}!", foo);
			
			Event.End();
		}
		
		static void simpleFunction() {
			Console.WriteLine("* I'm done already!");
		}
		
		static BlackThread Event = new BlackThread();	
		static Random Rand = new Random();
		
		static void Main() {		
			int r;
			
			do {
				if (!Event.IsActing) {
					Console.WriteLine();
					r = Rand.Next(3);
					
					if (r == 0) {
						Event.KickStart_(() => pausableFunction());
					}
					else if (r == 1) {
						simpleFunction();
					}
					else {
						Event.KickStart_(() => anotherFunction(Rand.Next(20) + 1));
					}
				}
				else {
					Event.Continue();
				}
				
				Console.Write("> ");
				Console.ReadKey();
			} while(true);
		}
	}
