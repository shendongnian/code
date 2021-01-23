    public HttpResponseMessage test([FromUri]int ID, [FromUri]List<string> accountID)
    {
        List<int> accountIdList = new List<int>();
        foreach (string accountId in accountID)
        {
            string[] arrAccountId = accountId.Split(new char[] { ',' });
            for (var i = 0; i < arrAccountId.Length; i++)
            {
                try
                {
                    accountIdList.Add(Int32.Parse(arrAccountId[i]));
                }
                catch (Exception)
                {
                }
            }
        }
    }
