     List<TreeNode> views;  // = new List<TreeNode>();
    
     views = res.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)   
                .Select(line => line.Split(','))   // second split, each line 
                .Select(t => new TreeNode
                {
                   Text = t[0],
                   ToolTipText = t[1]
                })
                .ToList( );
