	public partial class SlidingPuzzle {
		public void Run() {
			for(bool initialized=false, quit=false; ; ) {
				if(!initialized) {
					Reset();
					Console.Clear();
					ShowPrompt();
					initialized=true;
				}
				ShowStatics();
				ShowMatrix();
				if(quit||IsGameOver||IsFinished) {
					SetCursorToBottom();
					if(!quit)
						ShowOnEnd();
					if(!(quit=IsExit)) {
						initialized=false;
						continue;
					}
					break;
				}
				var keyInput=Console.ReadKey(true).Key;
				if(ConsoleKey.Escape==keyInput)
					quit=true;
				else if(ConsoleKey.LeftArrow==keyInput)
					Move(new[] { +0, +1 });
				else if(ConsoleKey.UpArrow==keyInput)
					Move(new[] { +1, +0 });
				else if(ConsoleKey.RightArrow==keyInput)
					Move(new[] { +0, -1 });
				else if(ConsoleKey.DownArrow==keyInput)
					Move(new[] { -1, +0 });
			}
		}
		void ReadOnExit() {
			Console.WriteLine("Press any key to exit ... ");
			Console.ReadKey(true);
		}
		bool IsExit {
			get {
				Console.WriteLine("Try again? (Y/N)");
				var quit=ConsoleKey.Y!=Console.ReadKey(true).Key;
				if(quit)
					ReadOnExit();
				return quit;
			}
		}
	}
