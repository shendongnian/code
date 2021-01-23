     private void LoadData()
     {
         foreach (ListItem item in check.Items)
         {
             if (item.Selected)
             {
                 DropDownList drop = new DropDownList();
                 drop.Items.Add("1");
                 drop.Items.Add("2");
                 drop.DataValueField = "1";
                 drop.DataValueField = "2";
                 drop.AutoPostBack = true;
                
                 // assign id property to dropdown.
                 drop.ID = "ddl_" + i.ToString();
                 // add event handled for dynamically generated dropdown      
                 drop.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                 TableRow row = new TableRow();
                 TableCell celula = new TableCell();
                 celula.Style.Add("width", "200px");
                 celula.Style.Add("background-color", "red");
                 celula.RowSpan = 2;
                 celula.Text = "item " + item.Value.ToString();
                 TableCell celula1 = new TableCell();
                 celula1.Style.Add("background-color", "green");
                 celula1.Style.Add("width", "200px");
                 celula1.RowSpan = 2;
                 TableCell celula2 = new TableCell();
                 celula2.Style.Add("width", "200px");
                 celula2.Style.Add("background-color", "blue");
                 celula2.Text = "unu";
                 TableRow row1 = new TableRow();
                 TableCell cel = new TableCell();
                 cel.Text = "lalala";
                 cel.Style.Add("background-color", "brown");
                 celula1.Controls.Add(drop);
                 row.Cells.Add(celula);
                 row.Cells.Add(celula1);
                 row.Cells.Add(celula2);
                 row1.Cells.Add(cel);
                 this.tabel.Rows.Add(row);
                 this.tabel.Rows.Add(row1);
             }
         }
        }
    
