            DateTime dateTime;
            String KeyWord = "11/12/13"; // MM/dd/yy
            if (DateTime.TryParse(KeyWord, out dateTime))
            {
                KeyWord = Convert.ToDateTime(KeyWord).ToString("MMMM"); // Full month name
                KeyWord = Convert.ToDateTime(KeyWord).ToString("MMM"); // The abbreviated name of the month. 
            }
