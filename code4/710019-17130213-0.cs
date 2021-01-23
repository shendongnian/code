    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    
     {
                SqlConnection con = new SqlConnection(@"server=xxxx-PC; database= sample;       integrated security= true");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblproduct ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                product prod = new product();
                
                // need to convert to integer, coz prodid is int
                prod.proid = Convert.ToInt32(dr[0].ToString());
                prod.prodname = dr[1].ToString();
                prod.unitprice = Convert.ToInt32(dr[2].ToString());
                // need to convert to string, textbox gets only string type
                // prod... => object_name.member_name
                textBox2.Text = prod.proid.ToString();
                // or u can u do: ..= prod.prodid+""; => this convert to str automatically             
                textBox3.Text = prod.prodname.ToString();
                textBox4.Text = prod.unitprice.ToString();
    } 
