     ListBox lst = new ListBox();
            {
                try
                {
                 lst.Location = new Point(4, 4);
                 btn.Size = new Size(60, 20);
                 btn.Tag = i;
                 comando.CommandText = "select ProductName from Products where productID = " + btn.Tag;
                 btn.Text = comando.ExecuteScalar().ToString() ;  // here error occurs why?
                 btn.Location = new Point(k, loc);
                }
                catch(Exception ex)
                {
                 MessageBox.Show(ex.Message);
                }
            }
