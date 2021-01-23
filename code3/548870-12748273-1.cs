    public class Dog : IComparable<Dog>
    {
     //this will allow you to do a quick name comparison
     public string Name { get; set;}
     public int CompareTo(Dog other)
     {//compare dogs by name
            return this._name.CompareTo(other.Name);
     }
    }
