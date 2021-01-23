    class Program
    {. 
        static void Main(string[] args)
        {
            Code code1 = new Code { Id = 1, Description = "Hi" };
            Code code2 = new Code { Id = 2, Description = "There" };
            switch (code1)
            {
                case 23: 
                  // do some stuff
                  break;
                // other cases...
            }
        }
    }
    public class Code
    {
        private int id;
        private string description;
        public int Id { get; set; }
        public string Description { get; set; }
        public static implicit operator int(Code code)
        {
            return code.Id;
        }
    }
