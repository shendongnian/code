    public YourMainFunction(){
        List<Person> allPersons = entityContext.Person.ToList();
        List<KeyValuePair<Person, Person>> personAndParents = new List<KeyValuePair<Person, Person>>();
        foreach(Person p in allPersons){
            personAndParents.Add(new KeyValuePair<Person, Person>(p, GetTopParent(p)));
        }
    }
    //Now you have a list of each Persons Parents in a key/value pair list.
    
    public Person GetTopParent(Person p){
        if(p.RelationHierarchy.Count(r=>r.ParentId != null) == 0){
            return p;
        }
        else{
            return GetTopParent(p.RelationHierarchy.FirstOrDefault(r=>r.ParentId != null).Person1); //This should be the parent relation, not the child relation, im not sure what you have named the relations.
        }
    }
