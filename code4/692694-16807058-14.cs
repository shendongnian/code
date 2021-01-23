    ChildItem MySelectedItem
    {
       get
       {
          return Items.FirstOrDefault(n=>n.MyItemIsSelected);
       }
    }
