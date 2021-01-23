    List<TreeNode> myNode = new List<TreeNode>();
    foreach (City MyData in giveData)
    {
        if (MyData.ListA != "")
        {
            myNode.Add(new TreeNode {
                listName = MyData.ListA, // Added for locating this parent node.
                id = count++,
                name = MyData.labelName,
                leaf = false,
                children = new List<TreeNode>()
            });
        }
        
        if (MyData.ListB != "")
        {
            // Get the "parent node"
            var parent = myNode.Find(t => t.listName == MyData.ListB); 
            if (parent != null)
            {
                parent.children.Add(new TreeNode {
                    id = count++,
                    name = MyData.labelName,
                    leaf = true
                });
            }
        }
    }
    return JsonConvert.SerializeObject(myNode);
