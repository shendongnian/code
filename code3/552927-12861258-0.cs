    Excel.Pictures p = myWorkSheet.Pictures(System.Type.Missing) as Excel.Pictures;
    Excel.Picture pic = null;
        
    pic = p.Insert(path + pic_name + ".png", System.Type.Missing);
    
    pic.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoCTrue;
    pic.ShapeRange.Width = 170;
    pic.ShapeRange.Height = 170;
    
    pic.Left = Convert.ToDouble(picPosition.Left);
    pic.Top = picPosition.Top;
