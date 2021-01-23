        private const string Charaters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890";
        static void Main(string[] args)
        {
            foreach (var c  in Charaters)
            {
                Console.Write(string.Format("{0}{1}", c, Environment.NewLine));
            }
        }
    }
