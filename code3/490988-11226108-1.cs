    private static void StudentDetails<T>()
    {
        ArrayList tmp = new ArrayList();
        foreach (Person p in people)
        {
            if (p is T)
            {
                tmp.Add(p);
            }
        }            
    }
