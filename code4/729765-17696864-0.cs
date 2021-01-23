    public YourMainFunction(){
        List<Person> allPersons = entityContext.Person.ToList();
        List<KeyValuePair<Person, Person>> personAndParents = new List<KeyValuePair<Person, Person>>();
        foreach(Person p in allPersons){
            personAndParents.Add(new KeyValuePair<Person, Person>(p, GetTopParent(p)));
        }
    }
    //Now you have a list of each Persons Parents in a key/value pair list.
    
    public Person GetTopParent(Person p){
        if(p.Parent == null){
            return p;
        }
        else{
            return GetTopParent(p.Parent);
        }
    }
