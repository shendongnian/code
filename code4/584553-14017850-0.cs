    private void Grid_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            UIElement element = Grid.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
            if (element == null)
                return;
        
            ColumnHeader clickedHeader = (ColumnHeader)element.GetContext(typeof(ColumnHeader), true);
        
            UltraGridColumn clickedColumn;
    
            if (clickedHeader != null)
                clickedColumn = clickedHeader.Column;
        
            if (clickedColumn == null)
                return;
            
            Switch ( clickedColumn.SortIndicator)
            {
               case SortIndicator.Ascending :
                   clickedColumn.SortIndicator= SortIndicator.Descending;
                   break;
               case SortIndicator.Descending :
                   clickedColumn.SortIndicator= SortIndicator.Disabled;
                   break;
               case SortIndicator.Disabled :
               default :
                   clickedColumn.SortIndicator= SortIndicator.Ascending;
                   break;
            }
        }
    }
