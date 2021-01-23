            SqlConnection con = new SqlConnection(@"PASTE_YoURCONNECTION_STRING_HERE"); 
            SqlDataAdapter usr = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + textBox1.Text + "'", con);
            SqlDataAdapter pswd = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE password='" + textBox2.Text + "'", con);
            DataTable dt1 = new DataTable(); //this is creating a virtual table  
            DataTable dt2 = new DataTable();
            usr.Fill(dt1);
            pswd.Fill(dt2);
            if (dt1.Rows[0][0].ToString() == "1" && dt2.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new mainform().Show();
            }
            else if (dt1.Rows[0][0].ToString() != "1" && dt2.Rows[0][0].ToString() != "1")
            {
                usrerror.Visible = true;
                pswrderror.Visible = true;
            }
            else if (dt1.Rows[0][0].ToString() == "1" && dt2.Rows[0][0].ToString() != "1")
            {
                usrerror.Visible = false;
                pswrderror.Visible = true;
            }
            else if (dt1.Rows[0][0].ToString() != "1" && dt2.Rows[0][0].ToString() == "1")
            {
                usrerror.Visible = true;
                pswrderror.Visible = false;
            }               
        }  `
