    Dictionary<int, Plan> dicPlan1 = new Dictionary<int, Plan>();
    dicPlan1.Add(1, new Plan());
    dicPlan1.Add(2, new Plan());
    dicPlan1.Add(3, new Plan());
    dicPlan1.Add(4, new Plan());
    listbox1.DataSource = new List<Plan>(dicPlan1.Values); //this will get you only the plans
    
    Dictionary<int, Plan> dicPlan2 = new Dictionary<int, Plan>();
    dicPlan2.Add(1, new Plan());
    dicPlan2.Add(2, new Plan());
    dicPlan2.Add(3, new Plan());
    dicPlan2.Add(4, new Plan());
    listbox2.DataSource = new List<Plan>(dicPlan2.Values); //this will get you only the plans
