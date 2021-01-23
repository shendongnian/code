            int offset=25;
            int xPos=50;
            int yPos = 10;
            foreach (string name in colNames)
            {
                Label l = new Label();
                l.Name = name;
                l.Width = 200;
                l.Text = name;
                
                TextBox t = new TextBox();
                t.Name = name; 
                t.Width=200;
                l.Location = new Point(xPos, yPos );
                t.Location = new Point(xPos+250, yPos);
               f.Controls.Add(l);
               f.Controls.Add(t);
               yPos = yPos + offset;
            }
            //TextBox t = new TextBox();//generate the controls u need
            //t.Text = "test";//set the actual value
            f.Width = 800;
            f.Height = 600;
            f.Show();
           
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
