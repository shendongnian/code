    List<ServiceReference1.Student> wcfStudentList = new System.Collections.Generic.List<ServiceReference1.Student>();
            foreach (var student in studentList)
            {
                wcfStudentList.Add(new ServiceReference1.Student()
                {
                    ID = student.ID,
                    Name = student.Name,
                    ..etc..
                });
            }
            var data = client.GetStudentData(wcfStudentList.ToArray());
