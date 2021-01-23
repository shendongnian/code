    private void btn_srch_sale_Click(object sender, EventArgs e)
        {
            int s;
            DataTable dt = new DataTable();
            SqlDataAdapter dat = new SqlDataAdapter();
            SqlConnection con = new SqlConnection("Data Source=Pakrelible\\SQLEXPRESS;AttachDbFilename=D:\\fuda\\Fuda.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            //SqlCommand dat = new SqlCommand();
            con.Open();
            dat.SelectCommand = new SqlCommand("SELECT * FROM sale_temp", con);
            dat.SelectCommand.Connection = con;
            s = dat.Fill(dt);
    
            if (s >= 1)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("Please Complete Sale Invoice First...!!!", "Error");
                this.aca.Focus();
                return;
            }
            int x;
            SqlConnection conn = new SqlConnection("Data Source=Pakrelible\\SQLEXPRESS;AttachDbFilename=D:\\fuda\\Fuda.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            ***SqlCommand copy = new SqlCommand("SELECT * FROM sale where inv_reff = @inv_reff ");   \\ problem goes here***
            copy.Parameters.Add("@inv_reff", SqlDbType.VarChar).Value = inv_sale.Text;
            conn.Open();
            copy.Connection = conn;
    
    
            SqlDataReader sale_copy = copy.ExecuteReader();
    
            while (sale_copy.Read())
            {
    
                aca_sale.Text = sale_copy["aca"].ToString();
                acn_sale.Text = sale_copy["acn"].ToString();
                act_sale.Text = sale_copy["act"].ToString();
                tele_sale.Text = sale_copy["tele"].ToString();
                memo_sale.Text = sale_copy["memo"].ToString();
                memo2_sale.Text = sale_copy["memo2"].ToString();
                inv_sale.Text = sale_copy["inv_reff"].ToString();
                inv_date_sale.Text = sale_copy["inv_date"].ToString();
                mode_sale.Text = sale_copy["mode"].ToString();
                reff_sale.Text = sale_copy["reff"].ToString();
                employe_sale.Text = sale_copy["employe"].ToString();
                dis_sale.Text = sale_copy["dis"].ToString();
    
    
    
                SqlDataAdapter da = new SqlDataAdapter();
                SqlConnection connn = new SqlConnection("Data Source=Pakrelible\\SQLEXPRESS;AttachDbFilename=D:\\fuda\\Fuda.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                da.InsertCommand = new SqlCommand("insert into sale_temp (aca,acn,act,tele,memo,memo2,inv_reff,inv_date,mode,reff,brand,part_no,descrp,qty,unt_prc,total_prc,employe,dis )" + "values(@aca,@acn,@act,@tele,@memo,@memo2,@inv_reff,@inv_date,@mode,@reff,@brand,@part_no,@descrp,@qty,@unt_prc,@total_prc,@employe,@dis )", connn);
                da.InsertCommand.Parameters.Add("@aca", SqlDbType.VarChar).Value = sale_copy["aca"].ToString();
                da.InsertCommand.Parameters.Add("@acn", SqlDbType.VarChar).Value = sale_copy["acn"].ToString();
                da.InsertCommand.Parameters.Add("@act", SqlDbType.VarChar).Value = sale_copy["act"].ToString();
                da.InsertCommand.Parameters.Add("@tele", SqlDbType.VarChar).Value = sale_copy["tele"].ToString();
                da.InsertCommand.Parameters.Add("@memo", SqlDbType.VarChar).Value = sale_copy["memo"].ToString();
                da.InsertCommand.Parameters.Add("@memo2", SqlDbType.VarChar).Value = sale_copy["memo2"].ToString();
                da.InsertCommand.Parameters.Add("@inv_reff", SqlDbType.VarChar).Value = sale_copy["inv_reff"].ToString();
                da.InsertCommand.Parameters.Add("@inv_date", SqlDbType.VarChar).Value = sale_copy["inv_date"].ToString();
                da.InsertCommand.Parameters.Add("@mode", SqlDbType.VarChar).Value = sale_copy["mode"].ToString();
                da.InsertCommand.Parameters.Add("@reff", SqlDbType.VarChar).Value = sale_copy["reff"].ToString();
                da.InsertCommand.Parameters.Add("@brand", SqlDbType.VarChar).Value = sale_copy["brand"].ToString();
                //da.InsertCommand.Parameters.Add("@brand", SqlDbType.VarChar).Value = sale_copy["brand"].ToString();
                da.InsertCommand.Parameters.Add("@part_no", SqlDbType.VarChar).Value = sale_copy["part_no"].ToString();
                da.InsertCommand.Parameters.Add("@descrp", SqlDbType.VarChar).Value = sale_copy["descrp"].ToString();
                da.InsertCommand.Parameters.Add("@qty", SqlDbType.VarChar).Value = sale_copy["qty"].ToString();
                da.InsertCommand.Parameters.Add("@unt_prc", SqlDbType.VarChar).Value = sale_copy["unt_prc"].ToString();
                da.InsertCommand.Parameters.Add("@total_prc", SqlDbType.VarChar).Value = sale_copy["total_prc"].ToString();
                da.InsertCommand.Parameters.Add("@employe", SqlDbType.VarChar).Value = sale_copy["employe"].ToString();
                da.InsertCommand.Parameters.Add("@dis", SqlDbType.VarChar).Value = sale_copy["dis"].ToString();
                //da.InsertCommand.Parameters.Add("@amnt_wrd", SqlDbType.VarChar).Value = sale_copy["amnt_wrd"].ToString();
    
    
                connn.Open();
                x = da.InsertCommand.ExecuteNonQuery();
    
                if (x >= 1)
                {
                    System.Media.SystemSounds.Asterisk.Play();
    
    
                    SqlConnection connnn = new SqlConnection("Data Source=Pakrelible\\SQLEXPRESS;AttachDbFilename=D:\\fuda\\Fuda.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                    DataTable sdt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT brand,part_no,descrp,qty,unt_prc,total_prc FROM sale_temp ", connnn);
                    sda.Fill(sdt);
                    sale_grid.DataSource = sdt;
                    connnn.Dispose();
    
                }
                else
                {
                    MessageBox.Show("Error Posting !", "Error");
                    }
    }
