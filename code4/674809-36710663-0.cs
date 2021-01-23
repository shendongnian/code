		public void RemoveFirstStringFromStringBuilder()
		{
			var lines = new StringBuilder();
			lines.AppendLine("abc");
			var firstLine = lines.ToString().IndexOf(Environment.NewLine, StringComparison.Ordinal);
			if (firstLine >= 0)
				lines.Remove(0, firstLine + Environment.NewLine.Length);
			Console.WriteLine(lines.Length);
			Console.WriteLine(lines.ToString());
		}
