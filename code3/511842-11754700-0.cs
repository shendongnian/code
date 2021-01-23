    //Create a list of path items
            List<string> mylist = market.Trim('~').Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    if (mylist.Count > 0)
    {
    //Add the root node
        TreeViewItem root = new TreeViewItem();
        root.Header = mylist[0];
        bool bfound=false;
        foreach (TreeViewItem subitem in treeview.Items)
            if (subitem.Header.ToString() == header)
                  bfound=true;
        if(!bfound)
            tree.Items.Add(root);
        mylist.RemoveAt(0);// remove the node already added
    //loop on a recursive manner
                TreeViewItem temp = root;
                foreach (string s in mylist)
                {
                    temp = AddNode(temp, s);
                }
                root.IsSelected = true;//we select the last node
            }
