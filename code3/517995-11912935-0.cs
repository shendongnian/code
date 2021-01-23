    //Start transaction here
    bool isSuccess = true;
    for (int i = 0; i < 100; i++)
    {
        try
        {
            //your Insert/update Query
        }
        catch (Exception ex)
        {
            isSuccess = false;
            break;
        }
    }
    
    if (isSuccess)
    {
        //Commit transaction 
    }
    else
    {
       //Roll back transaction
    }
