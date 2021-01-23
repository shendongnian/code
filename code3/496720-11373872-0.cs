     interface IInterface
        {
            string GetTopic(string one, string t = null);
        }
    
        class a : IInterface
        {
            public string GetTopic(string one, string t = null)
            {
                throw new NotImplementedException();
            }
        }
