    public string GetPersonalId (int n)
    {
        char letter1 = (char)('A' + ((n / 10 / 26 / 26) % 26));
        char letter2 = (char)('A' + ((n / 10 / 26) % 26));
        char digit1 = (char)('0' + ((n / 10) % 10));
        char digit2 = (char)('0' + ((n) % 10));
        string dateString = string.Format("{0:yyyyMMdd}", DateTime.Today)
            .Insert(6, " ")
            .Insert(3, " ");
    
        return string.Format("{0}{1} {2}{3} {4}",
            letter1, letter2, digit1, digit2, dateString);
    }
    public GetNextSequenceForToday()
    {
        SqlCommand query = new SqlCommand()
        query.CommandText =
           "SELECT COUNT(*) FROM [Users] " +
           "WHERE [Date] >= @today AND [Date] < @tomorrow";
        query.Parameters.Add("@today", DateTime.Today);
        query.Parameters.Add("@tomorrow", DateTime.Today.AddDays(1));
        int count = Convert.ToInt32(query.ExecuteScalar());
    
        return count + 1;
    }
