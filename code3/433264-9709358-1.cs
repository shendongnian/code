    for (int i = 0; i < ProxyList.Count; i++) {
      string[] split = List[i].Split('|');
      Records record = new Records() {
        Name = split[0]
        SomeValue = Int32.Parse(split[1])
        OrderNr = Int32.Parse(split[2])
      };
      Records.add(record);
    }
