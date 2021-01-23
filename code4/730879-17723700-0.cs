    var attachedItems = items.ToDictionary(
          w => w.Number,
          w => w.Attachments.Select(a => string.IsNullOrEmpty(a.Name) 
                                         ? a.EquipmentCode : a.Name)
                            .ToArray());
