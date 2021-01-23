     protected static string GetText(object dataItem)
     {
        string year = Convert.ToString(DataBinder.Eval(dataItem, "year"));
        if (!string.IsNullOrEmpty(year))
        {
            return year;
        }
        else
        {
            return "blahblah";
        }
     }
     
