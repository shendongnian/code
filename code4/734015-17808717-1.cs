      if (((JToken)obj).Type == JTokenType.Array)
      {
        Console.WriteLine("ARRAY!");
      }
      else if (((JToken)obj).Type == JTokenType.Object)
      {
        Console.WriteLine("OBJECT!");
      }
