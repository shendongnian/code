    // F#
    type Person = 
    {
        Name : string      
        Age : int
    }
    // C#
    var personRecord = new Person("John",1);
    var newPerson = personRecord.With(p => p.Age, 20);
