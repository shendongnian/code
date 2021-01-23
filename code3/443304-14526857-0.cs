    //---------- C# Dll Partial Source -----------
    
    public int RowShow
       { get { return vu.DisplayedRowCount(false); } }
		
    public int RowCount 
       { get { return vu.RowCount; } }
        
    public void PageMove(int rows)
    {
        int rowlimit = vu.RowCount - 1;
        int calc = vu.FirstDisplayedScrollingRowIndex + rows;
	
        if (calc > rowlimit) calc = rowlimit;  // Go to bottom
        if (calc < 0)        calc = 0;         // Go to top
			
        vu.FirstDisplayedScrollingRowIndex = calc;
    }
    
    // ---------- End Data Grid View ----------
    
    
    
    //---------- Calling Program C# ----------
    
    public void Page_Key(int val, int lastKey)
    {
        int inc = 1;                // vu is DataGridView
  
        If (val == 33) inc = -1;
  
        int rowsDisp = vu.RowShow;  // # of rows displayed
        int rowsMax  = vu.RowCount; // # of rows in view
        int rows     = 0;
  
        switch (lastKey)
        {        
          case 17:                  // Ctrl prior to Page
            rows = inc;
            break; 
          case 19:                  // Alt prior to Page
            rows = rowsMax * inc;
            break;
          default:
            rows = rowsDisp * inc
            break;
        }  // end switch
      vu.PageMove(rows)
    } // end Page_Key
    
    
    
    '----- Calling Program B4PPC, VB -----
   
    Sub Page_Key(val,lastKey)     ' 33=PageUp, 34=Down
        inc = 1                   ' vu is DataGridView
  
        If val = 33 then inc = -1
    
        rowsDisp = vu.RowShow     ' # of rows displayed
        rowsMax  = vu.RowCount    ' # of rows in view
        rows     = 0
        Select lastKey
          Case 17                 ' Ctrl prior to Page
            rows = inc 
          Case 19                 ' Alt prior to Page
            rows = rowsMax * inc
          Case Else
            rows = rowsDisp * inc
        End Select
    
        lastKey = ""
    
        vu.PageMove(rows)
    End Sub
