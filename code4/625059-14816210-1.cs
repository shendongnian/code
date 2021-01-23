    public static object _obj; // I can be changed on another thread!
    void PrintObj() {
      if (_obj != null)
        Console.WriteLine(_obj.ToString());
      }
    }
