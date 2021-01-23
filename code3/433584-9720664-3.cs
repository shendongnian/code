    int attempts = 0;
    bool success = false;
  
    while (!success && attempts < 3)
    {
        using (SQLCommand exists = new SQLCommand("SELECT ID FROM ... WHERE CCardNo = @cardNo AND PIN = @pin", conn))
        {
            exists.Parameters.AddWithValue("@cardNo", cardNum);
            exists.Parameters.AddWithValue("@PIN", pinnum);
            object idObject = (int)exists.ExecuteScalar();
            if (idObject == null || idObject == DBNull.Value)
            {
                attemps++;
            }
            else
            {
                success = true;
            }
            if (attempts >= 3)
            {
                // Lock out the user
            }
        }
    }
    if (success)
    {
        ...
    }
