    JsonConvert.DeserializeObject<A>("{number:'some thing'}", 
    new JsonSerializerSettings
    {
       Error = delegate(object sender, ErrorEventArgs args)
       {
          Console.WriteLine(args.ErrorContext.Error.Message);
          args.ErrorContext.Handled = true;
       }
    });
