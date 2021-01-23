    Delegate del = a1.Target as Delegate;
    if(del != null)
    {
        if(del.Method == a2.Method && del.Target == a2.Target)
        {
            Console.WriteLine("pass");
        }
    }
