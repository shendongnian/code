    object renewalDate = reader.GetValue(reader.GetOrdinal("M_RENEWALDATE"));
    if (Equals(renewalDate, DBNull.Value))
    {
        yourObject.M_RenewalDate = DateTime.MinValue;
    }
    else
    {
        yourObject.M_RenewalDate = (DateTime) renewalDate;
    }
