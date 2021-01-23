    if (view is GridView)
    {
       // auto best fit...
       (view as GridView).BestFitMaxRowCount = 5000;   // just to avoid to many compares
       (view as GridView).BestFitColumns();
       foreach (GridColumn item in (view as GridView).Columns) // reduce the width of very wide columns
       {
          item.Width = (item.Width > 1000) ? 1000 : item.Width;
       }
    }
