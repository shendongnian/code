    var xmlStr = @"<UserID>
      <Total>2</Total>
      <X1>2</X1>
      <Y1>4</Y1>
      <Attached1>2,3,4</Attached1>
      <X2>7</X2>
      <Y2>8</Y2>
      <Attached2>4,5,6</Attached2>
    </UserID>
    ";
    var doc = XDocument.Parse(xmlStr);
    var users =
        from user in doc.Descendants("UserID")
        let total = (int)user.Element("Total")
        select new
        {
            X = Enumerable.Range(1, total)
                          .Select(i => (int)user.Element("X" + i))
                          .ToArray(),
            Y = Enumerable.Range(1, total)
                          .Select(i => (int)user.Element("Y" + i))
                          .ToArray(),
            Attached = Enumerable.Range(1, total)
                                 .Select(i => (string)user.Element("Attached" + i))
                                 .ToArray(),
        };
