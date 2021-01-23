    RadToolBarDropDown dd = new RadToolBarDropDown("Drop Down - Handled Server Side");
    
            RadToolBarButton rtb = new RadToolBarButton();
            rtb.Text = "Bold";
            rtb.Value = "Bold";
            rtb.CommandName = "Bold";
            rtb.CommandArgument = "Bold";
            dd.Buttons.Add(rtb);
    
            rtb = new RadToolBarButton();
            rtb.Text = "Italic";
            rtb.Value = "Italic";
            rtb.CommandName = "Italic";
            rtb.CommandArgument = "Italic";
            dd.Buttons.Add(rtb);
    
            rtb = new RadToolBarButton();
            rtb.Text = "Underline";
            rtb.Value = "Underline";
            rtb.CommandName = "Underline";
            rtb.CommandArgument = "Underline";
            dd.Buttons.Add(rtb);
    
            rtlMyToolBar.Items.Add(dd as RadToolBarItem);
            
