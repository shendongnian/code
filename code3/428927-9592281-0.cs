    schoolBus.riders = new List<Person>
    {
        new Student { name = "Jim" },
        new Student { name = "Jane }
    }
    var query = from rider in SchoolBus.riders
    select new 
    {
        riderID = (rider as Student).studentId;
    }
