    SqlCommand l_findPayments = new SqlCommand("FindPayments", new SqlConnection("..."));
    l_findPayments.CommandType = CommandType.StoredProcedure;
    if ( l_totalPriceComparison == "Exact Amount" )
    {
        findPayments.Parameters.Add(new SqlParameter("@MinPrice", l_price));
        findPayments.Parameters.Add(new SqlParameter("@MaxPrice", l_price));
    }
    else if ( l_totalPriceComparison == "Below Amount" )
        findPayments.Parameters.Add(new SqlParameter("@MaxPrice", l_price));
    else if ( l_totalPriceComparison == "Above Amount" )
        findPayments.Parameters.Add(new SqlParameter("@MinPrice", l_price));
    // "Any Price" will just leave the parameter
    // blank, so it will not filter on price
    // ... repeat for all params
    SqlDataReader l_result = l_findPayments.ExecuteReader();
