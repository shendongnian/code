    private static void StudentDetails(Type type)
    {
        ArrayList tmp = new ArrayList();
        foreach (Person p in people)
        {
            if (p is type)
            {
                tmp.Add(p);
            }
        }            
    }
