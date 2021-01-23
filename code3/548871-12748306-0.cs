     public class Dog: IComparable<Dog>
     {
          private string _name;
          public Dog(string name)
          {
               _name = name;
          }
          public int CompareTo( Dog other )
          {
               return _name != null ? _name.CompareTo( other._name )
                                    : (other._name == null ? 0 : -1);
          }
     }
