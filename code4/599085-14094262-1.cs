    using (StreamReader sr = new StreamReader(f))
    {
        while (true)
        {
            string s = sr.ReadLine();
            if (s != null)
            {
                //If the line that was read isn't null, add a new instance of Appliance
                // to the list. You can assign the "name" field a value when you create
                // the instance by using the following format: "new Object() { variable = value }
                DatapowerList.Add(new Appliance() { name = s });
            }
            else
                break;
        }
    }
