    var q = from str in list
            let Parts = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            let item = Parts[ 0 ]
            let num = int.Parse(Parts[ 1 ])
            group new  { Name = item, Number = num } by item into Grp
            select new {
                Name  = Grp.Key,
                Value = Grp.Max(i => i.Number).ToString()
            };
    var highestGroups = q.Select(g => 
        String.Format("{0} {1}", g.Name, g.Value)).ToList();
