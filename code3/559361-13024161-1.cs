    [DataContract]
    public class C
    {
        [DataMember]
        public List<int> Values { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c = new C
            {
                Values = new List<int>()
            };
            var serializer = new DataContractSerializer(typeof(C));
            Task
                .Factory
                .StartNew(() => 
                {
                    while (true)
                    {
                        Console.WriteLine("Trying to add new item.");
                        c.Values.Add(DateTime.Now.Millisecond);
                    }
                }, 
                TaskCreationOptions.LongRunning);
            Task
                .Factory
                .StartNew(() =>
                {
                    while (true)
                    {
                        using (var stream = new MemoryStream())
                        {
                            Console.WriteLine("Trying to serialize.");
                            serializer.WriteObject(stream, c);
                        }
                    }
                },
                TaskCreationOptions.LongRunning);
            Console.ReadLine();
        }
