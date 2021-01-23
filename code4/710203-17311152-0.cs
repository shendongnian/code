   		public static DataTable dataFortheCombos()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(@"Data source=SAMANIEGO-PC\SQLEXPRESS; Initial Catalog=banco_de_datos; User Id=user; Password=xxx");/
            string query = "select id_person as identifier, identification_key +' '+dependence_key +' '+degree_or_title+' '+name+' '+ ap+' '+ am as completedetails from directory"; 
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);
            return dt;
        }
        
        public static AutoCompleteStringCollection autocompleteCombos()
        {
            DataTable dt = dataFortheCombos();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();           
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["completedetails"]));
            }
            return coleccion;
        }
		
		 public void fillCombos()
        {                                
            comboFrom.DataSource = dataFortheCombos();
            comboFrom.DisplayMember = "completedetails"; //This is the value shown on the combo for the user
            comboFrom.ValueMember = "identifier"; // The selectedc value insert as identifier (is a number)
            comboFrom.SelectedIndex = -1; //Clear the combo            
			
            //NOTE -> The others combos (urned over and sender) using the same data
                 
        }
		
