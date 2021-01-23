    DataRow dr=this.ordersBindingSource.Current;
      Combo.Text="";
      if(dr!=null)
      {
        if(dr[Combo.ValueMember]!=DBNull.Value)
        {
         Combo.SelectedValue=dr[Combo.ValueMember].ToString();        
         Combo.Text=dr[Combo.DisplayMember].ToString();         
        }
      }
