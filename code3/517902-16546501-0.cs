    private TestFactory addSubjectTreeStructure(String subjectField)
        {
            String folderRootString = subjectField;
            folderRootString = folderRootString.Replace("\\", "/");
            String[] folders = folderRootString.Split('/');
            // Test Plan Tree Manager
            TreeManager treeMgr = tdc.TreeManager;
            SubjectNode subjectNode = treeMgr.get_NodeByPath("Subject");
            ISysTreeNode node = (ISysTreeNode)subjectNode;
            // Creating the folders in test plan.
            for (int i = 0; i < folders.Length; i++)
            {
                try
                {
                    node = node.FindChildNode(folders[i]);
                }
                catch (Exception ex)
                {
                    node = node.AddNode(folders[i]);
                    Console.WriteLine(ex.Message + ".\nChild not found. Adding new node: " + folders[i]);
                }
            }
            // Set the leaf folder and then returning the TestFactory from where all test cases will be generated from.
            SubjectNode folder = treeMgr.get_NodeById(node.NodeID);
            return folder.TestFactory;
        }
