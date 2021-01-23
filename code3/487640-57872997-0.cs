	private class CustomFileStream : FileStream
	{
		private Action<string> WriteAction { get; }
		public CustomFileStream(Action<string> writeAction)
			// FileStream is notoriously hard to mock, so we inherit from it and we are a lightweight, real (but unused) FileStream underneath
			: base(Path.Combine(new ExecutionDirectory().Path /* Handle the execution directory in your own way */, "Content/DummyTextFile.txt"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
		{
			this.WriteAction = writeAction;
		}
		public override bool CanWrite => true;
		public override void Write(ReadOnlySpan<byte> buffer)
		{
			this.WriteAction(Encoding.UTF8.GetString(buffer));
		}
	}
