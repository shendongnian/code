        class Employee : IComparable
        {
           private string name;
           public   string Name
           {
              get { return name; }
              set { name = value ; }
           }
        
           public Employee( string a_name)
           {
              name = a_name;
           }
       
           #region IComparable Members
           public   int CompareTo( object obj)
           {
             Employee temp = (Employee)obj;
             if ( this.name.Length < temp.name.Length)
               return -1;
             else return 0;
           }
       }
