    void WriteStartAttribute(params string[] values) 
    {
         if (values.Length > 4 || values.Length < 2) throw new ArgumentException();
         if (values.Count == 2)
         {
            writer.WriteStartAttribute(values[1]);
         }
         else if (values.Count == 3)
         {
            writer.WriteStartAttribute(values[1], values[2]);
         }
         else if (writeInfo.Count == 4)
         {
            writer.WriteStartAttribute(values[1], values[2], values[4]);
         }
      }
