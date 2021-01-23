    class Program
    {
        private static void Main(string[] args)
        {
            IAuthor author = new Novelist();
            author.Name = "Raj";
            // i guess u have check if author is a novelist
            // the simple way is by safe typecasting
            Novelist novelist = author as Novelist;
            if (novelist != null)
            {
                Console.WriteLine("Wohoo, i am a novelist");
            }
            else
            {
                Console.WriteLine("Damn,i cant write novel");
            }
        }
