    //First of all, find the root level parent
    int  baseParent = "0"; 
    // Find the lowest root parent value
     foreach (var selection in collection)
     {
         //assign any random parent id, if not assigned before
          if (string.IsNullOrEmpty(baseParent))
            baseParent = selection["PrntID"];
    
         //check whether it is the minimum value
         if (Convert.ToInt32(selection["PrntID"]) < Convert.ToInt32(baseParent))
           baseParent = selection["PrntID"];
     }
    //If you are sure that your parent root level node would always be zero, then you could   //probably skip the above part.
    //Now start building your hierarchy
    foreach (var selection in collection)
    {
      CategoryItem item = new CategoryItem();
      //start from root
      if(selection["Id"] == baseParentId)
      {
        //add item property
        item.Id = selection["id];
        //go recursive to bring all children
        //get all children
        GetAllChildren(item , collection);
      }
    }
    
    
    private void GetAllChildren(CategoryItem parent, List<Rows> Collection)
    {
      foreach(var selection in Collection)
      {
         //find all children of that parent
         if(selection["PrntID"] = parent.Id)
         {
           CategoryItem child = new CategoryItem ();
           //set properties
           child.Id = selection["Id"];
           //add the child to the parent
           parent.AddSubCategory(child);
           //go recursive and find all child for this node now
           GetAllChildren(child, Collection);
         }
       }
    }
