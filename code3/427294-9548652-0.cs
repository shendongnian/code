    public class Person
    {
       public string name { get; set; }
       public int  age { get; set; }
    
       pulbic int ComparePerson(Person person, IComparable comparer)
       {
         return comparer.Compare(this, person);
       } 
    }
