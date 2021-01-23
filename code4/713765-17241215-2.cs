    SqlCommand l_findPayments = new SqlCommand("FindPayments", new SqlConnection("..."));
    l_findPayments.CommandType = CommandType.StoredProcedure;
    if ( l_totalPrice.HasValue /* or whatever "null check" you want to perform */ )
        findPayments.Parameters.Add(new SqlParameter("@TotalPrice", l_totalPrice.Value));
    // ... repeat for all params
    SqlDataReader l_result = l_findPayments.ExecuteReader();
