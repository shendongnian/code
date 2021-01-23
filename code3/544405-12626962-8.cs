    public class AClass
    {
        public static Dictionary<string, int> ProcessedQueue { get; set; }
        public void UpdateSession(string correlationKey)
        {
            var dictionary = ProcessedQueue; // HttpContext.Current.Application["ProcessedQueue"] as Dictionary<string, int>;
            if (dictionary == null)
            {
               dictionary = new Dictionary<string, int>();
               ProcessedQueue = dictionary;// HttpContext.Current.Application["ProcessedQueue"] = dictionary;
            }
        
            if (!dictionary.ContainsKey(correlationKey)) { dictionary.Add(correlationKey, 0); }
        
            for (int i = 0; i < 100; i++)
            {
                 dictionary[correlationKey] = i;
             System.Threading.Thread.Sleep(1000);
            }
        }
    }
