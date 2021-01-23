    //why make these for every item?
    var converter = new System.Windows.Media.BrushConverter(); 
    var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#FFB1D100"); 
    foreach (var x in GraphPanel.Children) 
    { 
        //this is tidier, but what if it's not a Path, is that possible?
        var path = (Path)x;
        //jump out here if it's not the right type, reduces nesting and removes one comparison
        if(!(path.Data is System.Windows.Media.EllipseGeometry)) continue;
         try
         {
             if (path.IsMouseOver)
             { 
                listViewPoints.SelectedItems.Add(listViewPoints.Items[PointIndex]); 
                path.Stroke = brush; 
                path.StrokeThickness = 8;      
                if (listViewPoints.SelectedItems.Count == 2) 
                {
                     double ptAX = ((Points)listViewPoints.SelectedItems[0]).A; 
                     double ptAY = ((Points)listViewPoints.SelectedItems[0]).B; 
                     double ptBX = ((Points)listViewPoints.SelectedItems[1]).A; 
                     double ptBY = ((Points)listViewPoints.SelectedItems[1]).B; 
     
                     //you're going to square these, so negatives don't matter
                     double diffX = ptAX - ptBX;
                     double diffY = ptAY - ptBY;
                     //the distance between the points = sqr/-diff in x squared + diff in y squared 
                     //don't use Math.Pow for squaring
                     double result = Math.Sqrt(diffX*diffX + diffY*diffY); 
                     CalculatedDistanceApart.Content = "Distance Apart: " + result + "'"; 
                 }
            } 
            PointIndex++; 
        } 
        catch { } 
    } 
