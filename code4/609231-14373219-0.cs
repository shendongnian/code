    public void editCommit(CEmployee emp)
        {
            try
            {
               Contract.Requires<ArgumentNullException>(null != emp, "Null argument, Parameter name : emp");
               this.employee.Name = emp.Name;
               this.employee.Age = emp.Age;
             }
             catch( ArgumentNullException x )
             {
                 System.Console.Error.WriteLine( "{0}: {1} @", typeof( x ).Name, x.Message );
                 System.Console.Error.WriteLine( "{0}", x.StackTrace };
                 //now throw the exception again so the caller can react to the error
                 throw;
             }
        }
