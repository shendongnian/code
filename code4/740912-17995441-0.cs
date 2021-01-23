    var task = Task.Factory.StartNew(() => 
    {
      for(int c = 0; c < arrayList.Count; c++)
      {
        SendAFrame(c);
      }
    });
