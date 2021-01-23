    //define class
    public class myClass
    {
        public int Column1;
        public string Column2;
    }
    // then
    var query = dt.AsEnumerable()
                  .Select(row => new myClass
                  {
                      Column1 = Convert.ToInt32(row[colsNames[0]]),
                      Column2 = row[colsNames[1]].ToString()
                  });
