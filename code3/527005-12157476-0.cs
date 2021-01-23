      List<People> pplList = LoadPeople();
    
      foreach (People person in pplList.OrderBy(pp => pp.ManagerID))
      {
        TreeNode[] parentArr = treeView1.Nodes.Find(person.ManagerID.ToString(), true);
        if (parentArr.Length == 0)
          treeView1.Nodes.Add(person.ID.ToString(), person.Name);
        else
          parentArr[0].Nodes.Add(person.ID.ToString(), person.Name);
      }
