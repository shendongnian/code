    class Program
	{
		static void Main(string[] args)
		{
            var d = new ManyList()
            {
                {"Hi", "Good", "People", "None", "Other"}
                {"Maybe", "Someone", "Else", "Whatever"}
            };
            Console.Read();
		}
	}
    class ManyList : List<string>
    {
        public void Add(params string[] strs)
        {
            Console.WriteLine(string.Join(", ", strs));
        }
    }
