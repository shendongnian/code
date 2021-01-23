    adap = new SqlDataAdapter("SELECT * FROM Employee; Select * from Shift; select * from Has_Shift", mycon);
    // second table name will be Employee +1
    adap.TableMappings.Add("Employee1", "Shift");
    // second table name will be Employee +2
    adap.TableMappings.Add("Employee2", "Has_Shift");
    
    // give Table name as below 
    adap.Fill(ds, "Employee");
    
    DataRow newRow = ds.Tables["Employee"].NewRow();
    newRow["Name"] = textBox1.Text;
    ds.Tables["Employee"].Rows.Add(newRow);
    adap.Update(ds);
    mycon.Close();
