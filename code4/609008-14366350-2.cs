        // this should be a Get() method, not a property.
        public List<SqlParameter> GetAttributes()
        {
            attributes = new List<SqlParameter>();
            SqlParameter sp = new SqlParameter();
            attributes.Add(new SqlParameter("id",this.id));
            attributes.Add(new SqlParameter("faculty", this.faculty));
            attributes.Add(new SqlParameter("AVG", this.AVG));
            attributes.Add(new SqlParameter("date", date));
            attributes.Add(new SqlParameter("educationInfo",educationInfo));
            attributes.Add(new SqlParameter("fatherName", fatherName));
            attributes.Add(new SqlParameter("lName", lName));
            attributes.Add(new SqlParameter("motherName", motherName));
            attributes.Add(new SqlParameter("password", password));
            attributes.Add(new SqlParameter("personalInfo", personalInfo));
            return attributes;
        }
