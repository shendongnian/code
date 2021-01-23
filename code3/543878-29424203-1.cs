    public class WordContainer
    {
        public WordContainer(string word)
        {
            Word = word;
        }
    
        public string Word { get; private set; }
        public string Result { get; set; }
    }
    
    public class WordMaker
    {
        public void MakeIt()
        {
            string[] words = { "ack", "ook" };
            List<WordContainer> containers = words.Select(w => new WordContainer(w)).ToList();
    
            Parallel.ForEach(containers, AddB);
    
            //containers.ForEach(c => Console.WriteLine(c.Result));
            foreach (var container in containers)
            {
                Console.WriteLine(container.Result);
            }
    
            Console.ReadKey();
        }
    
        public void AddB(WordContainer container)
        {
            container.Result = "b" + container.Word;
        }
    }
