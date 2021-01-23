    static void main(string[] args)
    {
      // Sleep some time
      int delay;
      if (args.Length > 0 && int.TryParse(args, out delay))
      {
        Thread.Sleep(delay);
      }
      // Initialize client
    }
