    private int CountLeapYears(DateTime startDate)
    {
        int count = 0;
        for (int year = startDate.Year; year <= DateTime.Now.Year; year++)
        {
            if (DateTime.IsLeapYear(year))
            {
                DateTime february29 = new DateTime(year, 2, 29);
                if (february29 >= startDate && february29 <= DateTime.Now.Date)
                {
                    count++;
                }
            }
        }
        return count;//The Execution will be terminated here,the next lines will become unreachable 
        **String** answer = GetAnswer();
        Response.Write(lblAntwoord); 
    }
    }
