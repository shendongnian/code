    // Assume the query results are in dtLoanPayments strongly typed datatable.
    // Also assume we have a TreeView called tvLoans
    dtLoanPayments.AsEnumerable().GroupBy(tr => tr.Grupo).ToList().ForEach(tr =>
    {
        (tr.Key == null ? tvLoans.Nodes : tvLoans.Nodes.Add(tr.Key)).AddRange
            (tr.Select(ti => { TreeNode tempNode = new TreeNode(ti.Nombre); tempNode.Tag = ti; return tempNode; }).ToArray());
    });
    
