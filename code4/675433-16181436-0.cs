        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int ID { get; set; }
            public string Email { get; set; }
            public string Country { get; set; }
    
            public void ClearStudentInfo()
            {
                Name = "";
                Age = 0;
                ID = 0;
                Email = "";
                Country = "";
            }
    
            public string FormatForOutput()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Name: ");
                sb.Append(Name);
                sb.Append("\nAge: ");
                sb.Append(Age);
                sb.Append("\nID: ");
                sb.Append(ID);
                sb.Append("\nE-Mail: ");
                sb.Append(Email);
                sb.Append("\nCountry: ");
                sb.Append(Country);
                return sb.ToString();
            }
        }
