    string tcpstring = "chunk1 : chunck2 : chunk3: chunk4 : chunck5 : chunk6";
    int numOfChunks = 4;
            
    var chunks = (from string z in (tcpstring.Split(':').AsEnumerable()) select z).Split(numOfChunks);
    List<string> result = new List<string>();
    foreach (IEnumerable<string> chunk in chunks)
    {
        result.Add(string.Join(":",chunk));                             
    }
    .......
    static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }
    }
    
