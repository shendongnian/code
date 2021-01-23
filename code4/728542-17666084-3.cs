        // Build the list
        List<string> text = new List<string>();
        text.Add("Group Hear It:");
        text.Add("    item: The Smiths");
        text.Add("    item: Fernando Sor");
        text.Add("Group See It:");
        text.Add("    item: Longmire");
        text.Add("    item: Ricky Gervais Show");
        text.Add("    item: In Bruges");
        text.Add("Group Buy It:");
        text.Add("    item: Apples");
        text.Add("    item: Bananas");
        text.Add("    item: Pears");
        // Query the list and create a "table" to work with
        var table = from t in text
                    select new {
                        Index = text.IndexOf(t),
                        Item = t,
                        Type = t.Contains("Group") ? "Group" : "Item",
                        GroupIndex = t.Contains("Group") ? text.IndexOf(t) : -1
                    };
        // Get the table in reverse order to assign the correct group index to each item
        var orderedTable = table.OrderBy(i => i.Index).Reverse();
        // Update the table to give each item the correct group index
        table = from t in table
                select new {
                    Index = t.Index,
                    Item = t.Item,
                    Type = t.Type,
                    GroupIndex = t.GroupIndex < 0 ?
                        orderedTable.Where(
                            i => i.Type == "Group" &&
                            i.Index < t.Index			
                        ).First().Index :
                        t.GroupIndex
                };
        // Get the "Hear It" items from the list
        var hearItItems = from g in table
                          from i in table
                          where i.GroupIndex == g.Index &&
                          g.Item == "Group Hear It:"
                          select i.Item;
        // Get the "See It" items from the list
        var seeItItems = from g in table
                         from i in table
                         where i.GroupIndex == g.Index &&
                         g.Item == "Group See It:"
                         select i.Item;
        // Get the "Buy It" items I added to the list
        var buyItItems = from g in table
                         from i in table
                         where i.GroupIndex == g.Index &&
                         g.Item == "Group Buy It:"
                         select i.Item;
