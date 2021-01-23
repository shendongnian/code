    List<Person> people = new List<Person>
    {
        new Male { IsFemale = false, MaleSpecificProperty = "Y" },
        new Male { IsFemale = false, MaleSpecificProperty = "Y" },
        new Female { IsFemale = true, FemaleSpecificProperty = "X" }
    };
 
    string json = JsonConvert.SerializeObject(people);
    var result = 
         JsonConvert.DeserializeObject<List<Person>>(json, new PersonConverter());
