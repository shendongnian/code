    public static object _obj; // I can be changed on another thread!
    void PrintObj() {
      Object obj = _obj;
      if (obj != null)
        Console.WriteLine(obj.ToString());
      }
    }
