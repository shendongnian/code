    public static bool operator ==(Person Person1, Person Person2)
    {
        if(object.ReferenceEquals(Person1, null)) {
            return object.ReferenceEquals(Person2, null);
        } else if(object.ReferenceEquals(Person2, null)) {
            return false;
        } else {
            return Person1.FirstName == Person2.FirstName && Person1.LastName == Person2.LastName;
        }
    }
