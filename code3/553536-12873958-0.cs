        var groups = lst.GroupBy(x => x.state);
        foreach (var group in groups) 
        {
            using (var f = new StreamWriter(group.Key + ".txt"))
            {
                foreach (var item in group)
                {
                    f.WriteLine(item.name);
                    f.WriteLine(item.url);
                }
            }
        }
