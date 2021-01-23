    public void Looping(Action onIncrement)
    {
       for (int i = 0; i < 100; i++)
       {
          Number = i;
          onIncrement(i);
          Sleep(10000);
       }
    }
    obj.Looping(() => Console.WriteLine(obj.Number));
