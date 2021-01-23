    Person oPerson =new Person();    
    var a= dictionary.Where(z => z.Key == key).FirstOrDefault();
    if (a.Count() > 0)
    {
       oPerson.ABC =  a.FirstOrDefault().Value;
    }
    
