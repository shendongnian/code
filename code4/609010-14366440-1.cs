        public List<SqlParameter> attributes
        {
            get
            {
                var myAttributes= new List<SqlParameter>();
                SqlParameter sp = new SqlParameter();
                myAttributes.Add(new SqlParameter("id",this.id));
                myAttributes.Add(new SqlParameter("faculty", this.faculty));
                myAttributes.Add(new SqlParameter("AVG", this.AVG));
                myAttributes.Add(new SqlParameter("date", date));
                myAttributes.Add(new SqlParameter("educationInfo",educationInfo));
                myAttributes.Add(new SqlParameter("fatherName", fatherName));
                myAttributes.Add(new SqlParameter("lName", lName));
                myAttributes.Add(new SqlParameter("motherName", motherName));
                myAttributes.Add(new SqlParameter("password", password));
                myAttributes.Add(new SqlParameter("personalInfo", personalInfo));
                return myAttributes;
            }
        }
