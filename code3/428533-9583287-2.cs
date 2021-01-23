        public static bool UpdateItem(Employee myEmployee)
       {
            if(myEmployee.IsDirty)
          {
                return myEmployeeDB.UpdateItem(myEmployee);
          }
       }
