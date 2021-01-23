    // First, group by group name. If it's null (meaning no group), then it will just be 
    // the person's name. Doing ToList() after grouping so we can do a ForEach.
    amortList.GroupBy(tr => string.IsNullOrEmpty(tr.Grupo) ? tvLoans : tvLoans.Add(tr.Grupo)).ToList()
        .ForEach(tr => 
        // This gives us the node we'll be adding each record to as the key. Now all
        // we need to do is add all loan records to the node, grouping by person
        {
            tr.Key.Nodes.AddRange(
                // Group by person's name first
                tr.GroupBy(ti => new TreeNode(ti.Nombre))
                    // Then transform into each node (loan payment, etc) and add to the person node.
                    .Select(ti => 
                    { 
                        ti.Key.Nodes.AddRange(
                            ti.Select(tn => new TreeNode(/*Use whatever field here to display.*/).ToArray());
                        return ti.Key; // Return TreeNode.
                    }).ToArray());
        }
