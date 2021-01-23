    class IdPrepender
    {
        private string id = Guid.NewGuid().ToString("N");
    
        public string Process(string input)
        {
            if (input == "BECOME")
            {
                id = Guid.NewGuid().ToString("N");
                return string.Empty;
            }
        
            return string.Format("{0}: {1}", id, input);
        }
    }
    …
    
    var block = new TransformBlock<string, string>(new IdPrepender().Process);
