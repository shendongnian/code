     interface ReadOnlyA
     {
        object A { get; }
     }
     interface WriteableA : ReadOnlyA
     {
       new object A {get; set;}
     }
