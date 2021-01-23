    tabControl1.SelectedIndex_Changed(object sender, EventArgs e)
    {
       if(tabControl1.SelectedIndex == 0)
       {
          txtTripNo.Visible = true; 
          txtTripNo2.Visible = false; 
       }
       else
       {
          txtTripNo.Visible = false; 
          txtTripNo2.Visible = true;
       }
    }
