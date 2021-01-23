    public static string GetNewType(string MType)
    {
      switch (MType)
        {
          case "MSG_1": return MSG_1;
          case "MSG_2": return MSG_2;
          default: throw new ArgumentException("MType");
        }
    }
