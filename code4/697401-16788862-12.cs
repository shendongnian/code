    var lst=Regex.Matches(input,@"(\w+)((?:\[.*?\])+)")
                 .Cast<Match>()
                 .Select(x=>new
                 {
                     name=x.Groups[1].Value,
                     value=Regex.Matches(x.Groups[2].Value,@"(?<=\[).*?(?=\])")
                                .Cast<Match>()
                                .Select(x=>new
                                {
                                     name=x.Groups[0].Value.Split('=')[0],
                                     value=x.Groups[0].Value.Split('=')[1]
                                })
                 });
