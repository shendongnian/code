    Dictionary<string,string> ProjectPerson(Person person)
    {
        var results = Dictionary<string,string>();
        results.Add("Name", person.name);
        results.Add("Surname", person.surname);
        for (int i=0;i<person.aspect.Count;++i)
        {
             results.Add("aspectKey" + i.ToString(), person.aspect[i].key);             
             results.Add("aspectValue" + i.ToString(), person.aspect[i].value);
        }
       
        return results;
    }
