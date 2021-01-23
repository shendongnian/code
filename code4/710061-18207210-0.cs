     private void button5_Click_2(object sender, EventArgs e) //add produt
        {
                SqlConnection con = new SqlConnection(@"Persist Security Info=False;User ID=usait;password=123;Initial Catalog=givenget;Data Source=RXN-PC\ROSHAAN");
                Dataset ds=new Dataset();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT product.p_name,product.p_category, product.sale_price FROM product where p_code='" + textBox16.Text + "'", con);
                da.Fill(ds);
                dataGridView3.DataSource = ds;
        
                //Code to insert values into Invoice
                for( i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   sqlcommand cmd=new sqlcommand();
                   cmd=new sqlcommand("insert into invoice(pname,pcategory,psaleprice) values('"+ds.Tables[0].Rows[i]["product.p_name"].ToString()+"','"+ds.Tables[0].Rows[i]["product.p_category"].ToString()+"','"+ds.Tables[0].Rows[i]["product.sale_price"].ToString()+"')",con);
                   cmd.executeNonquery();
                }
                con.close();
        
        }
