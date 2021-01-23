        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/Student/{studentID}")]
        void UpdateStudent(string studentID, Student student);
        public void UpdateStudent(string studentID, Student student) 
        {
            var findStudent = students.Where(s => s.StudentID == studentID).FirstOrDefault();
            if (findStudent != null)
            {
                findStudent.FirstName = student.FirstName;
                findStudent.LastName = student.LastName;
            }
        }
