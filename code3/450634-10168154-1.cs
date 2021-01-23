            using(StreamReader myFile = new StreamReader(path))
            {
                int index = 0;
                while(!myFile.EndOfStream)
                {
                    Employee E = new Employee();
                    E.EmployeeNum = Int32.Parse(myFile.ReadLine());
                    E.Name = myFile.ReadLine();
                    E.Address = myFile.ReadLine();
                    E.Wage = Double.Parse(myFile.ReadLine());
                    E.Hours = Double.Parse(myFile.ReadLine());
                    myEmployees[index++] = E;
                }
            }
