MySqlConnection sqlCon = new MySqlConnection("Server=***;Port=***;Database=***;Uid=***;Pwd=***;");
MySqlCommand commandText = new MySqlCommand ("SELECT count(Dues) From Students");
//sqlCon is of type MySqlConnection which is derived from DbConnection
sqlCon.CommandText = "SELECT * count(Dues) FROM Students";
//sqlCon has no Connection property, and why are you even assigning sqlCon to that property
sqlCon.Connection = sqlCon;
//ofcourse this will fail
TextBox1.Text = sqlCon.ExecuteScalar().ToString();
