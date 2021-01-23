     public class ConsoleDecorator : TextWriter
	{
		private TextWriter m_OriginalConsoleStream;
		public ConsoleDecorator(TextWriter consoleTextWriter)
		{
			m_OriginalConsoleStream = consoleTextWriter;
		}
		public override void WriteLine(string value)
		{
			m_OriginalConsoleStream.WriteLine(value);
			// Fire event here with value
		}
		
		public static void SetToConsole()
		{
			Console.SetOut(new ConsoleDecorator(Console.Out));
		}
	}
