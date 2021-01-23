    command.CommandText="SELECT Field1,...,FieldN FROM MyTable WHERE Condition = Value";
    SqlDataAdapter SDA = new SqlDataAdapter(command);
    SDA.Fill(MyDataTable);
    textBox1.Text = MyDataTable.Rows[0].Field<string>("Field1");
    comboBox1.Text = MyDataTable.Rows[0].Field<string>("FieldN");
