    using (dr = cmd.ExecuteReader())
    {
        while (dr.Read())
        {
            TestSubscriptionID = dr.GetInt32(dr.GetOrdinal("Subscription_ID"));
        }
        dr.Close();
    }
