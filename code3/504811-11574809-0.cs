    try
    {
        DateTime dt = Convert.ToDateTime(d.dob); // and what is dob ?
        int result = DateTime.Compare(young, dt);
        if (result < 0)
        {
            old = dt;
        }
        if (result > 0)
        {
            young = dt;
        }
    }
