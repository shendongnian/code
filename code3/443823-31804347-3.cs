    public HttpResponseMessage test([FromUri]int ID, [FromUri]string accountID)
    {
        List<int> accountIdList = new List<int>();
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
