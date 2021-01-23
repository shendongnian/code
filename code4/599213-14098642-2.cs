    protected void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
        String sqlQuery="select modelid,name From Modeltable where manufacturerid="+ Convert.ToInt16(comboBox4.SelectedValue.ToString());
    
        comboBox3.DataSource = cls.Select(sqlQuery);
        comboBox3.DataTextField = "name";
        comboBox3.DataValueField = "modelid";
        comboBox3.DataBind();
    }
 
