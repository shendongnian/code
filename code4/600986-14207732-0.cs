            SqlConnection conn = new SqlConnection(@"Integrated Security=True; Data Source=JODIEPC\XPRESS;Initial Catalog=TEST5");
            conn.Open();
            SqlCommand cmd = new SqlCommand("usp_EmployeeSelect", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@emp_id", SqlDbType.Int).Value = id;
          
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                department = dr["dept_name"].ToString();
                fname = dr["emp_first_name"].ToString();
                lname = dr["emp_last_name"].ToString();
                email = dr["emp_email"].ToString();
                phone = dr["emp_phone"].ToString();
                position = dr["emp_position"].ToString();
                address1 = dr["emp_address1"].ToString();
                address2 = dr["emp_address2"].ToString();
                city = dr["emp_city"].ToString();
                state = dr["emp_state"].ToString();
                postal_code = dr["emp_postal_code"].ToString();
            }
            
        }
       protected int id;
       protected string fname;
       protected string lname;
       protected string department;
       protected string email;
       protected string position;
       protected string address1;
       protected string address2;
       protected string phone;
       protected string city;
       protected string state;
       protected string postal_code;
        public int Id
       {
           get { return id; }
           set { id = value; }
       }
            
        public string Department
        {
           get { return department; }
           set{ department = value; }
        }
        
        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }
        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
 
        public string Position
        {
          get { return position; }
          set { position = value; }
        }
        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        
        public string City
        {
            get { return city; }
            set { city = value; }
        }
         public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string Postal_Code
        {
            get { return postal_code; }
            set { postal_code = value; }
        }
    }
