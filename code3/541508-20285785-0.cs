    a. **representation changing** (also called coercion)
       
        int i = 0;
        double d = i;
        object o = i; // (specifically called boxing conversion)
        IConvertible o = i; // (specifically called boxing conversion)
    Requires implicit conversion operator, changes the referential identity of the object being converted.
    b. **representation preserving** (also called implicit reference conversion)
        string s = "";
        object o = s; 
        IList<string> l = new List<string>();
    Only valid for reference types, never changes the referential identity of the object being converted, conversion always succeeds, guaranteed at compile time, no runtime checks. 
