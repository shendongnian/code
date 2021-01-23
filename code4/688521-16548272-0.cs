    public class InputCapture
    {
        public string Attribute { get; set; }
        public int Value { get; set; }
    }
    public class InputParser
    {
        const string pattern = @"(\w)(\d+)";
        private static readonly Regex Regex = new Regex(pattern);
        
        public IEnumerable<InputCapture> Parse(string input)
        {
            var inputs = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var parsedInputs = inputs.Where(i => Regex.IsMatch(i))
                                 .Select(i => Regex.Match(i))
                                 .Select(r =>
                                    new InputCapture
                                        {
                                            Attribute = r.Groups[1].Value,
                                            Value = int.Parse(r.Groups[2].Value)
                                        });
            return parsedInputs;
        }
    }
