    try {
      DoSomething();
    } catch (COMException ex) {
      Console.WriteLine ex.ErrorCode.ToString();
      Console.WriteLine ex.Message;
    }
