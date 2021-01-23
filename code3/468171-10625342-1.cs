    DateTime currentdate;
    int result;
    try
    {
      // EXAMPLE: 2012-04-15 15:23:34:123 
      DateTime backupdate =
         DateTime.ParseExact (
           "yyyy-MM-dd HH:mm:ss:fff", //mind the casing
           imageflowlabel.Text, 
           CultureInfo.InvariantCulture);
      currentdate = System.DateTime.Now.AddHours(-2);    
      result = currentdate.CompareTo(backupdate);
    }
    catch (Exception ex)
    {
      ...
