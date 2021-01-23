    List<ObjectB> C = new List<ObjectB>();
    foreach (n in B)
    {
        foreach (c in A)
        {
            if (n.idObjectA == c.idObjectA)
            {
                C.Add(n)
                break;
            }
        }
    }
