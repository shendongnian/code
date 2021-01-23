    Excel.Range picPosition = xlSShhh.Cells[2, 15];
    Excel.Pictures p = xlSShhh.Pictures(System.Type.Missing) as Excel.Pictures;
    Excel.Picture pic = null;
    try
    {
    pic = p.Insert(path + pic_name + ".png", System.Type.Missing);
    pic.ShapeRange.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoCTrue;
    pic.ShapeRange.Width = 180;
    pic.ShapeRange.Height = 180;
    }
    catch (Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
