    if(comboBox3.Text == "Books")
    {
       if (!treeView1.Nodes.ContainsKey("Books"))
       {
           TreeNode booksNode = new TreeNode("Books");
           booksNode.Name = "Books";
           treeView1.Nodes.Add(booksNode);
       }
      
       treeView1.Nodes["Books"].Nodes.Add(textBox1.Text);
    }
