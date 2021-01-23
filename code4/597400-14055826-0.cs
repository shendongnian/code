            int count = 1;
            List<TreeNode> myNode = new List<TreeNode>();
            foreach (City MyData in giveData)
            {
                // 1st foreach
                if (MyData.ListA != "")
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.id = count++;
                    treeNode.name = MyData.labelName;
                    treeNode.leaf = false;
                    foreach (City labelName in giveData)
                    {
                        if (MyData.ListA == labelName.ListB)
                        {// 2nd foreach
                            TreeNode node1 = new TreeNode();
                            node1.id = count++;
                            node1.name = labelName.labelName;
                            node1.leaf = true;
                            treeNode.Nodes.Add(node1);
                        }
                    }
                    myNode.Add(treeNode);
                }
            }
            return JsonConvert.SerializeObject(myNode);
