     private void LoadRootNodes(RadTreeView treeView, TreeNodeExpandMode expandMode)
     {
         //... your code
         if (Session["LastClickedNode"] !=null)
         {
              if (row["task_id"].ToString().TrimEnd() == Session["LastClickedNode"].ToString())
              {
                   node.Selected = true;
              } 
         }
     }
