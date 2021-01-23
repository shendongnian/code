    var list1 = chkboxlist.Items
                          .Cast<ListItem>()
                          .Where(item => item.Selected)
                          .Select(item => item.Value)
                          .Except(new[] { "4" });
