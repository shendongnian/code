    using (System.IO.StreamReader sr = new System.IO.StreamReader(textBox2.Text.Replace("'\'", "'\\'")))
    {
    	string line;
    	string macAddress;
    	while ((line = sr.ReadLine()) != null)
        {
    		macAddress = line.Substring(?,?) // get the macAddress from the loaded line here.  
                // you will need to replace the ?,? with the actual position info for that field.
    		DataRow row = dtt.Rows.Find(macAddress);
    		if (row != null) {
    			row["TxPower"] = line.Substring(78, 4);
    		}
         }
     }
     dataGridView1.DataSource = dtt; 
