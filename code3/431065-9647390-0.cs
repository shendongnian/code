    Console.Write(myCollection[surname].DisplayDetails());
    public class Students : KeyedCollection<string, Student>
    {
        // The parameterless constructor of the base class creates a 
        // KeyedCollection with an internal dictionary. For this code 
        // example, no other constructors are exposed.
        //
        public Students () : base() {}
    
        // This is the only method that absolutely must be overridden,
        // because without it the KeyedCollection cannot extract the
        // keys from the items. The input parameter type is the 
        // second generic type argument, in this case OrderItem, and 
        // the return value type is the first generic type argument,
        // in this case string.
        //
        protected override string GetKeyForItem(Student item)
        {
            // In this example, the key is the student's name.
            return item.Name;
        }
    }
