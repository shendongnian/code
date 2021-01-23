    Try this... simple
    System.Collections.Queue q = new System.Collections.Queue(4);
    q.Enqueue("hai"); q.Enqueue("how"); q.Enqueue("are"); q.Enqueue("u");
    int count = q.Count;
    List<string> list = new List<string>();
    for(int i =0; i < count; i++)
    {
       list.Add(q.Dequeue().ToString());
    }
