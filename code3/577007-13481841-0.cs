     private void rEdit_TextChanged(object sender, TextChangedEventArgs e)
       {
    
          if (rEdit.Selection != null)
          {
             var startpos = rEdit.Selection.Start;
    
             if (startpos != null)
             {
                var run = startpos.Parent as Run;
    
                if (run != null)
                {
                   int count = 0;
    
                   if (string.IsNullOrWhiteSpace(run.Text) == false)
                      count = run.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
    
                   run.ToolTip = new Run("Words: " + count);
                }
             }
          }
    
       }
