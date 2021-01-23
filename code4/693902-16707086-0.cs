	public class IllegalCSharpClass : DocumentService
	{
		public IllegalCSharpClass()
		{
			DocumentRepository = new DocumentRepository("B");
            base(); //This is illegal C#, but allowed in IL
		}
	}
