    public class ReplaceQuery : IQuery
    {
        private readonly string match;
        private readonly string text;
        public ReplaceQuery(string match, string text)
        {
            this.match = match;
            this.text = text;
        }
        public Data Process(Data data)
        {
            return data.Content.Contains(match) ? new Data {Content = data.Content.Replace(match, text)} : null;
        }
    }
    public class GreetingToQuery : IQuery
    {
        private readonly string greeting;
        private readonly string place;
        public GreetingToQuery(string greeting, string place)
        {
            this.greeting = greeting;
            this.place = place;
        }
        public Data Process(Data data)
        {
            return data.Content.Contains(greeting) ? new Data {Content = data.Content + place + "."} : null;
        }
    }
    public class LineEndingQuery : IQuery
    {
        public Data Process(Data data)
        {
            return data.Content.LastIndexOf(".", StringComparison.Ordinal) == data.Content.Length - 1 &&
                   data.Content.Length > 0
                       ? new Data {Content = "\n"}
                       : null;
        }
    }
