    var result = Regex.Matches(File.ReadAllText(fileName),
                                @"\{Atom\: Verdieping (\d)\}.*?\[`Max`(.*?)\]", 
                                RegexOptions.Singleline)
                .Cast<Match>()
                .Select(m => new{
                    Id = m.Groups[1].Value,
                    Nums = m.Groups[2].Value.Split(" \t\n\r".ToArray(),StringSplitOptions.RemoveEmptyEntries)
                })
                .ToList();
    foreach (var v in result)
    {
        Console.WriteLine(String.Format("Verdieping:{0} => {1}",v.Id,String.Join(",",v.Nums)));
    }
