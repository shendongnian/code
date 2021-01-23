    public List<Person> GetSortedList(List<Person> personList)
    {
       foreach (var person in personList)
       {
           person.CarList=person.CarList.OrderByDescending(x => x.Name== "BMW").ToList();
       }
     return personList;
    }
