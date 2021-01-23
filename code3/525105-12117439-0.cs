    void componentGrid_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
    
       //Loop through the rows and columns	
        for (int i = 0; i < componentGrid.Rows.Count; i++)
        {
            for (int j = 0; j < componentGrid.Cols.Count; j++)
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
            }
        }
 
