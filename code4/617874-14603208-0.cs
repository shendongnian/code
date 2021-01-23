    private const string tableNameMaterial = "Material_No";
    private const string tableNameProduct = "Product_Line";
    
    protected void SearchButton_Click(object sender, EventArgs e)
        {
            string Selectedvalue = DropDownList.SelectedItem.Value;
            if (DropDownList.SelectedItem.ToString() == "Material No")
            {
                //MessageBox.Show("Material No. Selected");
                string textbox = TextBox1.Text;
                //MessageBox.Show(textbox.ToString());
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ROG;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM ProductDB WHERE Material_No = @Material_No";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Material_No", SqlDbType.BigInt);
                cmd.Parameters["@Material_No"].Value = TextBox1.Text;
                
                SqlDataAdapter daMaterial = new SqlDataAdapter();
                daMaterial.SelectCommand = cmd;
                
                DataSet dsMaterial = new DataSet();
                conn.Open();
                daMaterial.Fill(dsMaterial, tableNameMaterial);
                
                //MessageBox.Show("Connection Successful");
                GridView1.DataSource = dsMaterial;
                GridView1.DataBind();
                
                conn.Close();
            }
            else
            {
                //MessageBox.Show("Product Line selected");
                string textbox = TextBox1.Text;
                //MessageBox.Show(textbox.ToString());
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ROG;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM ProductDB WHERE Product_Line = @Product_Line";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Product_Line", SqlDbType.VarChar);
                cmd.Parameters["@Product_Line"].Value = TextBox1.Text;
                SqlDataAdapter daProduct = new SqlDataAdapter();
                daProduct.SelectCommand = cmd;
                DataSet dsProduct = new DataSet();
                conn.Open();
                daProduct.Fill(dsProduct, tableNameProduct);
                //MessageBox.Show("Connection Successful");
                GridView1.DataSource = dsProduct;
                GridView1.DataBind();
                conn.Close();
            }
        }
