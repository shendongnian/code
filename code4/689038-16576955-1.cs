    public List<Student> ReturnAllStudentsList()
        {
            string jsonString = "[{'Response':'OK','UUID':'89172'},{'Response':'OK','UUID':'10304'}]";
            List<Student> Students = new List<Student>(); //Creates a list of custom Type: Student
            var result = JsonConvert.DeserializeObject<List<Student>>(jsonString);
            foreach (var student in result)
            {
                Students.Add(student);
            }
            return Students;
        }
