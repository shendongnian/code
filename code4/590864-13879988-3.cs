    @(Html.Kendo().TreeView().Name("TreeView").DragAndDrop(true)
    .Items(treeview =>
               {
                   foreach (var myItem in Model)
                   {
                       var myItemName = myItem.Name;
                       var children = myItem.Children;
                       treeview.Add().Text(myItemName ).Expanded(false).Items(branch =>
                                                                                 {
                                                                                      if (children != null)
                                                                                         {
                                                                                             foreach (var child in children)
                                                                                             {
                                                                                                 branch.Add().Text(child);
                                                                                             }
                                                                                         }
                                                                                 });
                   }
               }
       ))
