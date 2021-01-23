        static void Main(string[] args)
        {
            Message msg = new Message() { content = "The quick brown fox" };
            string message1 = Pack(msg);
            Console.WriteLine(message1);
            Message mess2 = Unpack(message1); // Step into... here be exceptions
            Console.Write(mess2.content);
        }
