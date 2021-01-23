    public void ScrollToBottom(Panel p){
      using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
         {
            p.ScrollControlIntoView(c);
            c.Parent = null;
         }
    }
    //use the code
    ScrollToBottom(yourPanel);
