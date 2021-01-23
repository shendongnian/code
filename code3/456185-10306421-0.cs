    private void cboPizzaType_SelectedIndexChanged(object sender, EventArgs e)         
    {           
	SqlConnection con = new SqlConnection(ItalianoLIB.DLL.DButils.CONSTR);             
	con.Open();              
	SqlDataAdapter da = new SqlDataAdapter("select PizzaPrice from pizza WHERE PizzaType='" + cboPizzaType.Text + "'", con);             
	DataTable dt = new DataTable();             
	da.Fill(dt);  
	con.Close(); 		   
	var oPrice = dt.Rows[0][0];
	this.pizzaPrice = (double)oPrice;
    }          
