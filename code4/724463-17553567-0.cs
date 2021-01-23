    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(lastname)) {
         if (!String.IsNullOrEmpty(phone))
         {
               List<Person> newList = List.FindAll(s => s.Name == name && s.Surname == lastname && s.Phone == phone);
         }
         else 
         {
              List<Person> newList = List.FindAll(s => s.Name == name && s.Surname == lastname);
         }
    }
