			public static void RunDialogue()
			{
				while (true) {
					Console.WriteLine("Type 'R' to RUN, 'E' to END");
					// KEY! Call ReadKeySingle instead
					ConsoleKey key = ReadKeySingle(); // Console.ReadKey().Key; //!!!
					Console.WriteLine("\r\n");
					switch (key) {
						case ConsoleKey.R:
							Console.WriteLine("RUN! ENGINES BLAST OFF!");
							Console.WriteLine("We blasted off at: " + DateTime.UtcNow);
							// BlastOff();
							break;
						case ConsoleKey.E:
							Console.WriteLine("FINISHED");
							return;
						default:
							Console.WriteLine("INVALID ENTRY, TRY AGAIN");
							// we *thought* this would pick up bad input, but not pasted text!
							break;
					}
				}
			}
