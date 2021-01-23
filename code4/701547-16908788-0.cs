      // start by loading the workbook
      HSSFWorkbook workbook;
      using (var stream = new FileStream(@"c:\Temp\birthdays.xls", FileMode.Open))
      {
        var fs = new POIFSFileSystem(stream);
        workbook = new HSSFWorkbook(fs);
      }
      // now get the worksheet that has the birthdays; I am just using the first sheet
      var birthdaySheet = workbook.GetSheetAt(0);
      // we are going to populate a list of Birthday objects in memory that we can then sort and write back into the file;
      // the Birthday class is defined below
      var birthdays = new Collection<Birthday>();
      for (int i = 0; i < birthdaySheet.LastRowNum; i++) // the LastRowNum property is very useful!
      {
        birthdays.Add(new Birthday
                        {
                          Name = birthdaySheet.GetRow(i).GetCell(0).StringCellValue, // name is in column A, which is 0
                          Bday = birthdaySheet.GetRow(i).GetCell(1).NumericCellValue // birthday is in column B, which is 1
                        });
      }
      // now we sort the birthdays
      var sorted = birthdays.OrderBy(b => b.Name).ToArray();
      // now we go back through the cells and write over the values with the sorted values
      for (int i = 0; i < sorted.Length; i++)
      {
        birthdaySheet.GetRow(i).GetCell(0).SetCellValue(sorted[i].Name);
        birthdaySheet.GetRow(i).GetCell(1).SetCellValue(sorted[i].Bday);
      }
      // finally, save the workbook
      using (var stream = new FileStream(@"c:\temp\birthdays.xls", FileMode.Truncate))
      {
        workbook.Write(stream);
      }
