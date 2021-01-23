       string sQry = "Select * from TestEmp"; // Select Table
       SqlCommand cmd = new SqlCommand(sQry, conDB);// Pass Sql Query & Sql Connection in Sql Command
       conDB.Open();// Open DB
       SqlDataAdapter objAdapter = new SqlDataAdapter(cmd); // Create DisConnected Architecture
       DataTable objTable = new DataTable(); // Create Data Table
       objAdapter.Fill(objTable);// Fill Data Table using Adapter Object
       dgvDisplay.DataSource = objTable; // Display select result in DataGridView Box
       conDB.Close(); // Close Connection
