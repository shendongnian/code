    public List<AccountDto> getSearchedAccount(int accountid, int userid, string holdername, string type, double balance, string status)
    {
        var results = new List<AccountDto>();
        
        for (int i = 0; i < list.Count; i++)
        {
            AccountDto dto = (AccountDto)list[i];
            
            if (accountid != default(int) && accountid != dto.Accountid)
                continue;
            if (userid != default(int) && userid != dto.Userid)
                continue;
            if (!string.IsNullOrEmpty(holdername) && !holdername.Equals(dto.Holdername))
                continue;
            if (!string.IsNullOrEmpty(type) && !type.Equals(dto.Type))
                continue;
            if (balance != default(double) && balance != dto.Balance)
                continue;
            if (!string.IsNullOrEmpty(status) && !status.Equals(dto.Status))
                continue;
            results.Add(dto);
        }
        
        return results;
    }
