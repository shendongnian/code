    //created a copy of the class properties
    tempSegments = new Segments();  // otherwise you are just changing the properties on a single obj and adding that obj many times to your list.
    tempSegments.List1 = new List<double>(list1);
    tempSegments.List2 = new List<double>(list2);
    tempSegments.List3 = new List<double>(list3);
    tempSegments.List4 = new List<double>(list4);
