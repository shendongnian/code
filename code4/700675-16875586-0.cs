            string[] personArray;
             
            List<Person> people = new List<Person>();
            foreach (string line in lines)//lines are the people from file, it is correct
            {
              Person tempPerson = new Person();
              personArray = line.Split(',');
              if (personArray.Length == 2)
              {
               tempPerson.Name = personArray[0];
               tempPerson.Address = personArray[1];
               people.Add(tempPerson);
              }
            }
