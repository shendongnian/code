    var attachedItems = items.ToDictionary(
                                   w => w.Number,
                                   w => w.Attachments.Select(a => {
                                     if(String.IsNullOrEmpty(a.Name) == false) 
                                        return a.Name; 
                                      return a.EquipmentCode;
                                  }).ToArray()
                         );
