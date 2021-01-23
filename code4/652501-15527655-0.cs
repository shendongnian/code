    resourceDictionary.Select((p, i) => new {p.Key, p.Value, Cell = i + 1})
       .ToList()
       .ForEach(item => {
             excelSheet.Cells[item.Cell, 1] = item.Key;
             excelSheet.Cells[item.Cell, 2] = item.Value;
               });
