    List<Project> list4 = new List<Project>();
    for(int i=1; i<list.Count; i++)
    { 
        list4.Add(new Project
        {
           ProjectId = list1[i].ProjectId;
           ProjectName = list1[i].ProjectName;
           Customer = list2[i].Customer;
           Address = list3[i].Address;
        });
    }
