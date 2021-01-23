    for (int i = _from; i <= _to; i++)
    {
        try
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (condition is false)
                {
                    // in here is the stuff you wanted to run in your using
                }
                //having nothing out here means you'll be out of the using immediately if the condition is true
            }
        } //x
    }
    //y
