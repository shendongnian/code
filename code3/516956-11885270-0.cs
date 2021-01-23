    DateTime dateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date"]);
    string date = string.Format("{0}{1} {2} {3}", dateTime.Day, GetOrdinal(dateTime.Day), dateTime.ToString("MMM"), datetTime.Year);
    
    public string GetOrdinal(int number)
    {
            switch(number % 100)
            {
    			case 11:
    			case 12:
    			case 13:
    					return "th";
            }
            switch(number % 10)
            {
                    case 1:
                            return "st";
                    case 2:
                            return "nd";
                    case 3:
                            return "rd";
                    default:
                            return "th";
            }
    }
