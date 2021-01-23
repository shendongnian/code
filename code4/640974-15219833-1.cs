	static Dictionary<String, String> Read(String path) {
		return (
			from line in File.ReadAllLines(path)
			where false==String.IsNullOrEmpty(line)
			group line by Alphabet(line) into g
			select
				new {
					Value=String.Join(",", g.ToArray()),
					Key=g.Key
				}
			).ToDictionary(x => x.Key, x => x.Value);
	}
