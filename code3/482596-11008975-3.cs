    XElement root = XElement.Load("Employees.xml");
    TreeNode rootNode = new TreeNode(root.Name.LocalName);
    treeView1.Nodes.Add(rootNode);
        foreach(XElement employee in root.Elements())
               {
                TreeNode employeeNode = new TreeNode("Employee ID :" + employee.Attribute("employeeid").Value);
                rootNode.Nodes.Add(employeeNode);
                     if (employee.HasElements)
                     {
                        foreach(XElement employeechild in employee.Descendants())
                         {
                            TreeNode childNode = new TreeNode(employeechild.Value);
                            employeeNode.Nodes.Add(childNode);
                         }
                     }
                }
