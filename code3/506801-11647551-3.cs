	private void Form1_Load ( object sender, EventArgs e )
	{
		string xml = "<MainList><number>5</number><first id=\"1\" name=\"test\" /><second/><third/></MainList>";
		XDocument doc = XDocument.Parse ( xml );
		var elements = doc.Root // "MainList"
			.Elements () // Elements inside "MainList"
			.Skip ( 1 ); // Skip first item ("number")
		// Add a TreeNode for each element on first level (inside MainList)
		foreach ( var item in elements )
		{
			// Create first-level-node
			TreeNode node = new TreeNode ( item.Name.LocalName );
			// Create subtree, if necessary
			TreeNode[] nodes = this.GetNodes ( node, item ).ToArray ();
			// Add node with subtree to TreeView
			treeView1.Nodes.AddRange ( nodes );
		}
	}
