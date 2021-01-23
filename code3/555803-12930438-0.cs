    static Hashtable GetHashtable(string Table )
        {
            Hashtable hashtable = new Hashtable();
               switch(table)
              {
            case "Edinburgh":
            hashtable.Add("Aberdeen", 129);
            hashtable.Add("Ayr", 79);
            hashtable.Add("Fort_William", 131);
            hashtable.Add("Glasgow", 43);
            hashtable.Add("Inverness", 154);
            hashtable.Add("St_Andrews", 50);
            hashtable.Add("Stirling", 36);
            break;
               ................
            return hashtable;
        }
