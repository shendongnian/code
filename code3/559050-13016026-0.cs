    Panel pnlPlaceHolder = (Panel)e.Item.FindControl("pnlPlaceHolder");
    if (pnlPlaceHolder!= null)
    {
         // The new control, a button, by example          
         Button btn = new Button();
         btn.Text = "Added dinamically";
         pnlPlaceHolder.Controls.Add(btn);
    }
