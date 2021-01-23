        private void FindUsedRange()
    {
       Excel.Worksheet wks = this.ActiveSheet as Excel.Worksheet;
    
       if (wks != null)
       {
          wks.UsedRange.Select();
       }
    }
