    cmd.Parameters.Add("Price", SqlDbType.Decimal).Value = price;
    cmd.Parameters.Add("User", SqlDbType.NChar, 20).Value = user;
    cmd.Parameters.Add("Time", SqlDbType.NChar, 15).Value = time;
    cmd.Parameters.Add("Customer", SqlDbType.NChar, 10).Value = customer;
    cmd.Parameters.Add("Discount", SqlDbType.Decimal).Value = discount;
    cmd.Parameters.Add("FullPrice", SqlDbType.Decimal).Value = fullPrice;
