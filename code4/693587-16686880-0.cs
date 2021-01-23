    XmlReader xr = XmlReader.Create(new StringReader(final_output));
           while (xr.Read())
           {
               switch (xr.Name)
               {
                   case "FEATURE":
                        TreeNode root = MyTreeView.Nodes.Add("FEATURE");
                       if (xr.HasAttributes)
                       {
                           while (xr.MoveToNextAttribute())
                           {
                               if (xr.Name == "NAME")
                               {
                                   TreeNode workingNode = root.Nodes.Add(xr.Value.ToString());
                                   liste.Add(xr.Value);
                               }
                           }
                       }
                       break;
               }
           }
