    public class DummyDto
    {
        public string Name { get; set; }
		
        public DummyDto Parent { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dummyDto = new DummyDto();
            //Both if statements will be true below
            if(dummyDto.Parent?.Name == null)
            {
                Console.WriteLine("DummyDto is null");
            }
            if (dummyDto.Parent == null || dummyDto.Parent.Name == null)
            {
                Console.WriteLine("DummyDto is null");
            }
		}
	}
