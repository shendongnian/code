    void Main()
    {
	  var d = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "First",
                    new Dictionary<string, string>
                    {
                        {"A", "ash"},
                        {"B", "brett"},
                        {"R", "ripley"},
                        {"J", "jones"},
                        {"D", "dallas"}
                    }
                },
                {
                    "Second",
                    new Dictionary<string, string>
                    {
                        {"A", "ash"},
                        {"B", "brett"},
                        {"R", "ripley"},
                        {"D", "dallas"},
                        {"K", "kane"}
                    }
                },
                {
                    "Third",
                    new Dictionary<string, string>
                    {
                        {"A", "ash"},
                        {"B", "brett"},
                        {"R", "ripley"},
                        {"D", "dallas"},
                        {"V", "vasquez"}
                    }
                },
                {
                    "Fourth",
                    new Dictionary<string, string>
                    {
                        {"A", "ash"},
                        {"B", "brett"},
                        {"R", "ripley"},
                        {"D", "dallas"},
                        {"H", "hicks"}
                    }
                }
            };
    var u = d.Values.SelectMany(x => x.Keys).Distinct().Where(y => d.Values.SelectMany(z => z.Keys).Count(a => a == y) == 1).ToArray();
            foreach (var f in u)
            {
                Console.WriteLine("{0} => {1}", f, d.Keys.Single(s => ((Dictionary<string, string>)d[s]).ContainsKey(f)));
            }
}
