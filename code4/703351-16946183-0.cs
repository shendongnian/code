    public class Currency
    {
      ...
      public override string ToString()
      {
        return String.Format("Currency Code: {0}\nUnit:{1}...",...);
      }
    }
    foreach (string key in dict.Keys)
    {
      Console.WriteLine("Key: {0}\nValue{1}", key, dict[key].ToString());
    }
