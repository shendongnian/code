    dynamic ProjectPerson(Person person)
    {
        dynamic result = new ExpandoObject();
        var results = result as IDictionary<string, object>();
        results.Add("Name", person.name);
        results.Add("Surname", person.surname);
        for (int i=0;i<person.aspect.Count;++i)
        {
             results.Add("aspectKey" + i.ToString(), person.aspect[i].key);             
             results.Add("aspectValue" + i.ToString(), person.aspect[i].value);
        }
       
        return result;
    }
