        public class ConnectedUser{
            public string FirstName{get;set;}
            public string LastName{get;set;}
            public override string ToString(){
                return string.format("FirstName{0}{1}{2}LastName{0}{3}",EqualDelimiter, FirstName, EntryDelimiter, LastName);
            }
         }
