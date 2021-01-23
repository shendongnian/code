    Rectangle rectangleUnderMouse = null;
    foreach( var rec in rectangles )
    {
      if( VisualTreeHelper.HitTest( rec, pointWhereMouseIs ) )
      {
        rectangleUnderMouse = rec;
        break;
      }
    }
