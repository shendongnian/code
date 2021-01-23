csharp
        class CustomExcelFormat
        {
            [Column("District")]
            public int District { get; set; }
            [Column("DM")]
            public string FullName { get; set; }
            [Column("Email Address")]
            public string EmailAddress { get; set; }
            [Column("Username")]
            public string Username { get; set; }
            public string FirstName
            {
                get
                {
                    return Username.Split('.')[0];
                }
            }
            public string LastName
            {
                get
                {
                    return Username.Split('.')[1];
                }
            }
        }
Notice, it allows me to map based on column name if I want to! 
Then when I process the excel file all I need to do is something like this:
csharp
        public void Execute(string localPath, int sheetIndex)
        {
            IWorkbook workbook;
            using (FileStream file = new FileStream(localPath, FileMode.Open, FileAccess.Read))
            {
                workbook = WorkbookFactory.Create(file);
            }
            var importer = new Mapper(workbook);
            var items = importer.Take<CustomExcelFormat>(sheetIndex);
            foreach(var item in items)
            {
                var row = item.Value;
                if (string.IsNullOrEmpty(row.EmailAddress))
                    continue;
                UpdateUser(row);
            }
            DataContext.SaveChanges();
        }
Now, admittedly, my code does not modify the Excel file itself.  I am instead saving the data to a database using Entity Framework (that's why you see "UpdateUser" and "SaveChanges" in my example).  But there is already a good discussion on SO about how to [save/modify a file using NPOI][4].
  [1]: http://www.zoeller.us/blog/2018/10/24/easiest-way-to-import-excel-files-in-c
  [2]: https://www.nuget.org/packages/NPOI/
  [3]: https://github.com/donnytian
  [4]: https://stackoverflow.com/questions/27507412/edit-existing-excel-file-c-sharp-npoi
