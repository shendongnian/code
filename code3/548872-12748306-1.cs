     public class Dog: IComparable<Dog>
     {
          private string _name;
          public Dog(string name)
          {
               _name = name;
          }
          public int CompareTo( Dog other )
          {
               return string.Compare( _name, other._name );
          }
     }
