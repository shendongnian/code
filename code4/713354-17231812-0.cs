    using(OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\jay.desai\Documents\Visual Studio 2008\Projects\Test\Test\Test.mdb"))
    using(OleDbCommand cmd = new OleDbCommand("insert into EmpTest values(@Emp_No,@Gender,@Language)", con))
    {
        con.Open();   
        cmd.Parameters.AddWithValue("@Emp_No", textBox1.Text);
        cmd.Parameters.AddWithValue("@Gender", GetGender());
        cmd.Parameters.AddWithValue("@Language", GetLanguages());
        cmd.ExecuteNonQuery();
    }
    
    private string GetLanguage()
    {
         StringBuilder result = new StringBuilder();
         if (checkBox1.Checked)
             result.AppendFormat("{0},", checkBox1.Text);
         if (checkBox2.Checked)
             result.AppendFormat("{0},", checkBox2.Text);
         if (checkBox3.Checked)
             result.AppendFormat("{0},", checkBox3.Text);
         if (checkBox4.Checked)
             result.AppendFormat("{0},", checkBox4.Text);
         if(result.Length > 0) result.Lenght--;
         return result.ToString();
    }
    private string GetGender()
    {
        return (radioButton1.Checked ? radioButton1.Text : radioButton2.Text);
    }
