    string[] lis = {"a","b","a.a","a.ab","c","cc.a","a.b.dd","samad.hah.hoh"};
    
                foreach (TreeNode _node in treeView1.Nodes)
                {
                    this._fieldsTreeCache.Nodes.Add((TreeNode)_node.Clone());
                }
                treeView1.Nodes.Clear();
                TreeBuilder Troot = new TreeBuilder();
                TreeBuilder son;
                Troot.depth = 0;
                Troot.index = 0;
                Troot.text = "root";
                Troot.childs = new Dictionary<string, TreeBuilder>();
    
                foreach (string str in lis)
                {
                    string[] seperated = str.Split('.');
                    son = Troot;
                    int index= 0;
                    for (int depth = 0; depth < seperated.Length; depth++)
                    {
                        if (son.childs.ContainsKey(seperated[depth]))
                        {
                            son = son.childs[seperated[depth]];
                        }
                        else {
                            son.childs.Add(seperated[depth],new TreeBuilder());
                            son = son.childs[seperated[depth]];
                            son.index= ++index;
                            son.depth = depth+1;
                            son.text = seperated[depth];
                            son.childs = new Dictionary<string, TreeBuilder>();
                        }
                    }
                }
                treeView1.Nodes.Add("root");
                Troot.addToTreeVeiw(treeView1.Nodes[0], Troot);
