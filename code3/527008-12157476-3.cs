    protected void Page_Load(object sender, EventArgs e)
    {
      List<People> pplList = LoadPeople();
      foreach (People person in pplList.OrderBy(pp => pp.ManagerID))
      {
        IEnumerable<TreeNode> nodes = Extensions.GetItems<TreeNode>(TreeViewPeople.Nodes, item => item.ChildNodes);
        TreeNode parent = nodes.FirstOrDefault(nn => nn.Value.Equals(person.ManagerID.ToString()));         
        TreeNode newNode = new TreeNode(person.Name, person.ID.ToString());
        if (parent == null)
          TreeViewPeople.Nodes.Add(newNode);
        else
          parent.ChildNodes.Add(newNode);          
      }
    }
