    string provider = ConfigurationManager.ConnectionStrings["databaseConnString"].ProviderName; 
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
           //Open Connection
            DbConnection conn = factory.CreateConnection();
            //Assign Connection String
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["databaseConnString"].ConnectionString; 
            //Connection Open
            conn.Open();
            //Initialize Command
            DbCommand comm = conn.CreateCommand();
            //Tell command which connection it will use
            comm.Connection = conn;
            //Give command SQL to execute
            comm.CommandText ="Insert into userinfo(UserName, Passwrd, FirstName, LastName, Address, Address2, City, State, ZipCode, Email, Gender, Age, ShirtSize, PantSize, EmailSubscribe) values(@UserName, @Passwrd, @FirstName, @LastName, @Address, @Address2, @City, @State, @ZipCode, @Email, @Gender, @Age, @ShirtSize, @PantSize, @EmailSubscribe)";                     
            
			SqlParameter userName = new SqlParameter("@UserName", SqlDbType.VarChar);
			paramUserName.Value = userName.Text;
			comm.Parameters.Add(userName);
			SqlParameter password = new SqlParameter("@Passwrd", SqlDbType.VarChar);
			myParam.Value = password.Text;
			comm.Parameters.Add(password);
			SqlParameter firstName = new SqlParameter("@FirstName", SqlDbType.VarChar);
			myParam.Value = FirstName.Text;
			comm.Parameters.Add(firstName);
			SqlParameter lastName = new SqlParameter("@LastName", SqlDbType.VarChar);
			myParam.Value = lastName.Text;
			comm.Parameters.Add(lastName);
			SqlParameter lastName = new SqlParameter("@LastName", SqlDbType.VarChar);
			myParam.Value = lastName.Text;
			comm.Parameters.Add(lastName);
			SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar);
			myParam.Value = address.Text;
			comm.Parameters.Add(address);
			SqlParameter address2 = new SqlParameter("@Address2", SqlDbType.VarChar);
			address2.Value = address2.Text;
			comm.Parameters.Add(address2); 
			SqlParameter city = new SqlParameter("@City", SqlDbType.VarChar);
			city.Value = city.Text;
			comm.Parameters.Add(city); 
			SqlParameter state = new SqlParameter("@State", SqlDbType.VarChar);
			state.Value = state.Text;
			comm.Parameters.Add(state); 
			SqlParameter zipCode = new SqlParameter("@ZipCode", SqlDbType.VarChar);
			zipCode.Value = zipCode.Text;
			comm.Parameters.Add(zipCode);
			SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar);
			email.Value = email.Text;
			comm.Parameters.Add(email);
			SqlParameter genderRadioGroup = new SqlParameter("@GenderRadioGroup", SqlDbType.VarChar);
			genderRadioGroup.Value = genderRadioGroup.Text;
			comm.Parameters.Add(genderRadioGroup);
			SqlParameter age = new SqlParameter("@Age", SqlDbType.VarChar);
			age.Value = age.Text;
			comm.Parameters.Add(age);
			SqlParameter drpShirtSizeCategory = new SqlParameter("@ShirtSize", SqlDbType.VarChar);
			drpShirtSizeCategory.Value = drpShirtSizeCategory.Text;
			comm.Parameters.Add(drpShirtSizeCategory);
			SqlParameter drpPantSizeCategory = new SqlParameter("@PantSize", SqlDbType.VarChar);
			drpPantSizeCategory.Value = drpPantSizeCategory.Text;
			comm.Parameters.Add(drpPantSizeCategory);
			SqlParameter emailRadioGroup = new SqlParameter("@EmailSubscribe", SqlDbType.VarChar);
			emailRadioGroup.Value = EmailRadioGroup.Text;
			comm.Parameters.Add(emailRadioGroup);
                        
			//Execute command get back result via reader
			int totalCount = comm.ExecuteNonQuery();
			DbCommand comm2 = conn.CreateCommand();
			comm2.CommandText = "Select @@Identity";
			comm2.Connection = conn;
			String id = comm2.ExecuteScalar().ToString();
			conn.Close();
			lblMessage.Text = "ID of User Added = " +id;
