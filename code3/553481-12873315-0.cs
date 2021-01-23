     if(cmbMonth.Text=="feb")  //if(cmbMonth.SelectedIndex.Equals(specify index))
      {
        for(i=0;i<29;i++)
        {
           cmbDay.Item.Add(i.ToString());
        }
      }
      else
       {
        for(i=1;i<32;i++)
        {
           cmbDay.Item.Add(i.ToString());
        }
       }
