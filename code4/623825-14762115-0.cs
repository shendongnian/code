    var choices = string.Join(",", chbxRoomChange.Items
                                                 .Cast<ListItem>()
                                                 .Where(li => li.Selected)
                                                 .Select(li => li.Text)
                                                 .ToArray()); 
