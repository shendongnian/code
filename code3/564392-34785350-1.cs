		public static void WriteLineMultithread(string strt) {
			int lastx=Console.CursorLeft,lasty=Console.CursorTop;
			Console.MoveBufferArea(0,lasty,lastx,1,0,lasty+1,' ',Console.ForegroundColor,Console.BackgroundColor);
			Console.SetCursorPosition(0,lasty);
			Console.WriteLine(strt);
			Console.SetCursorPosition(lastx,lasty+1);
		}
