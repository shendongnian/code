      string dateAsString = Convert.ToString(DateTime.Now);
      var list = new object[] { 27, "foo bar", 12.34m, true, dateAsString };
      var serializer = new DataContractJsonSerializer(typeof (List<object>));
      using (MemoryStream ms = new MemoryStream())
      {
        serializer.WriteObject(ms, list);
        ms.Position = 0;
        var deserializedList = serializer.ReadObject(ms) as List<object>;
        DateTime dateTime = Convert.ToDateTime(deserializedList[4]);
      }
