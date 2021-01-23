      var mydelegate = new Action<object>(delegate(object param)
      {
        Console.WriteLine(param.ToString());
      });
      mydelegate.Invoke("test");
