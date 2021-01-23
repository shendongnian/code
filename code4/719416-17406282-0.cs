        Thread t=null;
    List<Thread> lst = new List<Thread();
        for (int i = 0; i <=5; i++)
        {
             t = new Thread(() => PasswdThread(i));
             lst.Add(t);
             t.Start();  
        }
        
        //how wait all thread, and than return value?   
    foreach(var item in lst)
    {
        while(item.IsAlive)
        {
             Thread.Sleep(5);
        }
    }
        return num;
