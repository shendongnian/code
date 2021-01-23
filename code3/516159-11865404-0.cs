    Lock (this)
    
    {
    
    this.MyDV.BeginInvoke(new MethodInvoker(delegate()
      {                 
        string[] park = Regex.Split(line, @",");
        try
        {
            //Insert new row
            MyDatasset.MyTableRow row = this.MyDataSet.MyTable.NewMyTableRow();
            row.Message = park[0].Trim();
            row.From = park[1].Trim();              
            this.MyDataSet.MyTable.Rows.Add(row);
    
            //Set color text for new row
            DataGridViewRow myrow = (from DataGridViewRow r in MyDV.Rows
                                     where (long)r.Cells[clId.Name].Value == row.Id
                                     select r).FirstOrDefault();
            if (myrow != null)
            {
                myrow.Cells[clFrom.Name].Style.ForeColor = Color.Blue;
                myrow.Cells[clMessage.Name].Style.ForeColor = Color.Blue;
            }       
        }
        catch { }
        try
        {
            this.MyDV.FirstDisplayedScrollingRowIndex = this.MyDV.Rows[this.MyDV.Rows.Count - 2].Index; //Scroll to lastest row
        }
        catch { }       
    }));  }
    
    }
