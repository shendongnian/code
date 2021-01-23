       var list = new DataTemplate[dsTmp.Tables[0].Rows.Count];
       for(int i = 0; i< dsTmp.Tables[0].Rows.Count; i++)
        {
            var item = new DataTemplate
            {
                lblText = "Count: ",
                txtBoxContent = dsTmp.Tables[0].Rows[i][0].ToString();
            };
            list[i] = item;
        }
        this.DataContext = list;
