    public void WithdrawMoney(bool throwOnError = false)
    {
        //Do stuff
        catch(Exception ex)
        {
            if(throwOnError) throw;
        } 
        //Do stuff
    }
    public void TransferMoney()
    {
        WithdrawMoney(true);
    }
