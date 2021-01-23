    var gp = GroupByPairs(
                new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("a", "d"),
                        new Tuple<string, string>("f", "h"),
                        /*  you get the idea */
                    }.GetEnumerator());
    
    foreach (var groupData in gp)
    {
        Console.WriteLine(groupData.ToString());
    }
    //recursive take on the problem
    private static IEnumerable<GroupPair> GroupByPairs(
        IEnumerator<Tuple<string, string>> pairs)
    {
        // result Groups
        var listGroup = new List<GroupPair>();
        if (pairs.MoveNext())
        {
            var item = pairs.Current;
            var current = new GroupPair(item);
    
            var subgroup = GroupByPairs(pairs); // recurse
                    
            // loop over the groups
            GroupPair target = null;
            foreach (var groupData in subgroup)
            {
                // find the group the current item matches
                if (groupData.Keys.Contains(item.Item1) ||
                    groupData.Keys.Contains(item.Item2))
                {
                    // determine if we already have a target
                    if (target == null)
                    {
                        // add item and keep groupData
                        target = groupData;
                        groupData.Add(item);
                        listGroup.Add(groupData);
                    }
                    else
                    {
                        // merge this with target
                        // do not keep groupData 
                        target.Merge(groupData);
                    }
                }
                else
                {
                    // keep groupData
                    listGroup.Add(groupData);
                }
            }
            // current item not added
            // store its group in the listGroup
            if (target == null) 
            {
                listGroup.Add(current);    
            }
        }
        return listGroup;
    }
    
    public class GroupPair
    {
        private static int _groupsCount = 0;
        private int id;
    
        public GroupPair(Tuple<string, string> item)
        {
            id = Interlocked.Increment(ref _groupsCount);
            Keys = new HashSet<string>();
            Items = new List<Tuple<string, string>>();
            Add(item);
        }
    
        // add the pair and update the Keys
        public void Add(Tuple<string, string> item)
        {
            Keys.Add(item.Item1);
            Keys.Add(item.Item2);
            Items.Add(item);
        }
    
        // Add all items from another GroupPair
        public void Merge(GroupPair groupPair)
        {
            foreach (var item in groupPair.Items)
            {
                Add(item);
            }
        }
    
        public HashSet<string> Keys { get; private set; }
    
        public List<Tuple<string, string>> Items { get; private set; }
    
        public override string ToString()
        {
            var build = new StringBuilder();
            build.AppendFormat("Group {0}", id);
            build.AppendLine();
            foreach (var pair in Items)
            {
                build.AppendFormat("{0} {1}", pair.Item1, pair.Item2);
                build.AppendLine();
            }
            return build.ToString();
        }
    }
