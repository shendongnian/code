        try{  bs.DataSource = PassBindingSource.bst;
        
        DataTable dt = (DataTable)PassBindingSource.bst.DataSource;
        
        
        List<string> colNames = GetColumnNames(dt);
        
        int offset = 25;
        int xPos = 50;
        int yPos = 50;
        
        foreach (string name in colNames)
         {
        Label l = new Label();
         l.Name = name;
        l.Width = 200;
        l.Text = name;
        
        
        TextBox t = new TextBox();
         t.Name = name;
        t.Width = 200;
        
         // BindingOperations.SetBinding(t, t.TextProperty, bs);
        
        //binding operation
        t.DataBindings.Add(new Binding("Text", bs, t.Name, true));
        
        l.Location = new Point(xPos, yPos);
        t.Location = new Point(xPos + 250, yPos);
        
        
        this.Controls.Add(l);
        this.Controls.Add(t);
        
        yPos = yPos + offset;
        
        // dgDetailsView.DataSource = bs;
         }
        
        }
        catch (Exception ex)
         {
         MessageBox.Show(ex.Message);
        }
                  
                    
                   
        }
        
        
        
        private List<string> GetColumnNames(DataTable table)
        {
        List<string> lstColNames=new List<string>();
        
        if (table != null)
        {
        
              lstColNames=
        
              (from DataColumn col in table.Columns
        
               select col.ColumnName).ToList();
          
        
        }
        
        return lstColNames;
        
             
        
        }
