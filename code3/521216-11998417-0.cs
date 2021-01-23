    int temp;
    using (SqlCommand selectUser = new SqlCommand(cmdStr, cn))
    {
        temp = Convert.ToInt32(selectUser.ExecuteScalar().ToString());
    }
    if (temp == 0)
    {
        string insCmd = ...;
        using (SqlCommand insertUser = new SqlCommand(insCmd, cn))
        {
            ...
        }
    }
