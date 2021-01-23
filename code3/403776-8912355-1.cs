    protected void JumpToRow(int rowNumber)
    {
       if(rowNumber>=0 && myGrid.Items!=null && rowNumber<myGrid.Items.Count)
       {
          var border = VisualTreeHelper.GetChild(myGrid, 0) as Decorator;
          if (border != null)
          {
             var scroll = border.Child as ScrollViewer;
             if (scroll != null) scroll.ScrollToEnd();
             scroll.ScrollToStart();
             for(int i=0;i<rowNumber;++i)
             {
                scroll.LineDown();
             }
          }
       }
    }
