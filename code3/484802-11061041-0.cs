    public override bool Equals(object other) {
        if(other == this) return true;
        
        var person = other as Person;
        if(person == null) return false;
        
        return person.Name == Name && person.Age == Age && person.Zip == Zip && person.Sex == Sex;
    }
    public override int GetHashCode() {
        //some logic to create the Hash Code based on the properties. i.e.
        return (Name + Age + Zip + Sex).GetHashCode(); // this is just a bad example!
    }
