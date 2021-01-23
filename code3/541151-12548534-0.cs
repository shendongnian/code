    var qry = from t in LVNewBill.Items
              where t.Text.Contains(InsertChange) 
              select t;
    
    foreach(var item in qry)
    {
          item.Selected = true;
          item.EnsureVisible();
          item.SubItems[1].Text = txtdetails.Text;
          item.SubItems[2].Text = txtperiod.Text;
          item.SubItems[3].Text = txtduedate.Text;
          //Might want to consider TryParse here
          double newtxtamt  = double.Parse(txtamt.Text); 
          item.SubItems[4].Text = newtxtamt.ToString("###,###,##0.#0");
    }
