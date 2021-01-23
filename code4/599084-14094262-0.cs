    using (StreamReader sr = new StreamReader(f))
    {
        Appliance Datapower = new Appliance(); //Notice the "= new Appliance()" on this line.
        while ((Datapower.name = sr.ReadLine()) != null)
        {
            DatapowerList.Add(Datapower);
        }
    }
