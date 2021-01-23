    void componentGrid_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
    {
           var value = componentGrid.GetCellCheck(e.Row,e.Col);
           //Your custom condition
           if (value is bool)
           {
              //Will hide the cell
              e.Style.Display = DisplayEnum.None;
           }
           else
           {
               //Will show the cell  
     	       e.Style.Display = DisplayEnum.Stack;
           }
    }
    
        
 
