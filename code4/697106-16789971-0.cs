    DataTable dtImage = new DataTable();
    
    dtImage.Columns.Add("Path");
    dtImage.Columns.Add("Name");
    
    dtImage.Rows.Add(new object[] { "ImagePath", "ImageText" });
    dtImage.Rows.Add(new object[] { "ImagePath", "ImageText" });
    dtImage.Rows.Add(new object[] { "ImagePath", "ImageText" });
    
    CreateImageGrid(dtImage);
