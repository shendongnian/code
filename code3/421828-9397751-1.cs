    List<string>[] list;
    List<Thread> threads; = new List<Thread>()
    list = dbConnect.Select();
    
    for (int i = 0; i < list[0].Count; i++)
    {
        Thread th = new Thread(() =>{
            sendMessage(list[0]['1']);
            //calling callback function
        });
        th.Name = "SID"+i;
        th.Start();
        threads.add(th)
    }
    
    for (int i = 0; i < list[0].Count; i++)
    {
        threads[i].DoStuff()
    }
