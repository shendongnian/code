    public class myRows
            {
                public List<decimal> Cols = new List<decimal>();
                public string myDateTimeCol { get; set; }
    
                public myRows(string str)
                {
                    var fields = str.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                    int x;
                    for (x = 0; x < fields.length-5;x++){
                       decimal d;
                       if (Decimal.TryParse(fields[x], out d)){
                          Cols.Add(d);
                       }
                    }
                    myDateTimeCol = string.Format("{0} {1} {2} {3} {4}", fields[x++], fields[x++], fields[x++], fields[x++], fields[x++]);
                }
            }
