        public class Parameters
        {
            //Properties.
            public string CompanyName
            {
                get;set;
            }
            public string ProductName
            {
                get;set;
            }
            public string Design
            {
                get;set;
            }
            public string Size
            {
                get;set;
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Parameters para = new Parameters();
            if (cbxCompanyName.Text.Trim().Length != 0)
            {
                para.CompanyName = "'" + this.cbxCompanyName.Text + "'";
            }
            if (cbxProductName.Text.Trim().Length != 0)
            {
                para.ProductName = "'" + this.cbxProductName.Text + "'";
            }
            if (cbxDesign.Text.Trim().Length != 0)
            {
                para.Design = "'" + this.cbxDesign.Text + "'";
            }
        }
        public void test(Parameters paras)
        {
            try
            {
                con = new SqlConnection(source);
                con.Open();
                string select;
             
                select = "SPGetSaleRegCulture ";
                DataSet ds = new DataSet();
                cmd = new SqlCommand(select, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company", paras.CompanyName);
                cmd.Parameters.AddWithValue("@Product", paras.ProductName);
                cmd.Parameters.AddWithValue("@Design", paras.Design);
                cmd.Parameters.AddWithValue("@Size", paras.Size);
                
                da.SelectCommand = cmd;
                
                da.Fill(ds, "SaleRegister");
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
