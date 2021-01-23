    for(int i=0; i<10; i++)
    {
        Addresses.Add(new Address(){Meter = "",Slave = i});
    }
    for (int i = 0; i < 10; i++)
    {
        Addresses[i].Meter = Convert.ToString(i);
    }
