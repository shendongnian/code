    public class SomeClass
    {
        private Dictionary<char, ScoresandPercentiles> function()
        {
            var _mappings = File.ReadAllLines("file.txt").Select(line =>
                    {
                        var splitt = line.Split(new char[] { ' ' },
                                                StringSplitOptions.
                                                RemoveEmptyEntries);
                        return new ScoresandPercentiles
                        {
                            foo = splitt[0],
                            foo1 = splitt[1],
                            foo2 = splitt[2],
                        };
                    }).ToDictionary(mkey => mkey.foo[0]);
            return _mappings;
        }
    }
    internal class ScoresandPercentiles
    {
        public string foo;
        public string foo1;
        public string foo2;
    }
