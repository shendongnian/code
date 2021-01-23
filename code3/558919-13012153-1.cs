    public event EventHandler Increment;
    public void Looping()
    {
       for (int i = 0; i < 100; i++)
       {
          Number = i;
          if (Increment != null)
          {
              Increment(this, EventArgs.Empty);
          }
          Sleep(10000);
       }
    }
    obj.Increment += (s, e) => Console.WriteLine(obj.Number);
    obj.Looping();
