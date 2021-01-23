     List<TreeNode> views =  res  // new List<TreeNode>();    
          .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)   
          .Select(line => line.Split(','))   // second split, process each line 
          .Select(t => new TreeNode
          {
            Text = t[0],
            ToolTipText = t[1]
          })
          .ToList( );
