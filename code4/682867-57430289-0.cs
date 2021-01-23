            Detail tc = new Detail();
       
            tc.Name = txtName.Text;
            tc.Contact = "92"+txtMobile.Text;
            tc.Segment = txtSegment.Text;
            var datetime = DateTime.Now;
            tc.Datetime = datetime;
            tc.RaisedBy = Global.Username;
            dc.Details.InsertOnSubmit(tc);
            try
            {
         
                dc.SubmitChanges();
                MessageBox.Show("Record inserted successfully!");
                txtName.Text = "";
                txtSegment.Text = "";
                txtMobile.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record inserted Failed!");
            }
