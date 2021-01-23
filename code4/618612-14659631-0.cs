    void c1FlexGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ht = c1FlexGrid1.HitTest(e);
 
            if (ht.CellType == CellType.Cell)
            {
                //do something
            }
        }
