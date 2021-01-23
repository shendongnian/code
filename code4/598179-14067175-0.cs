    List<int> selSender = CheckBoxList1.Items.OfType<ListItem>()
                                       .Where(i => i.Selected)
                                       .Select(i => Convert.ToInt32(i.Value))
                                       .ToList();
    
    RadGrid1.DataSource = from m in myEntities.Messages
                          where selSender.Contains(m.CreatedByUserID)
                          select new { 
                              m.Id,
                              m.MessageText,
                              m.CreatedByUserID 
                          };
