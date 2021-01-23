    SqlCommand maxIdCmd = new SqlCommand("SELECT MAX(Id_racuna) FROM Racun", cn);
    maxID = Convert.ToString(maxIdCmd.ExecuteScalar());
    maxID = maxID != "" ? Convert.ToString(Convert.ToInt32(maxID) + 1) : "1";
    string stmt = "INSERT INTO Racun(Znesek, Uporabnik, Cas, Kupec, Popust, Poln_znesek) " + 
                  "VALUES(@Price, @User, @Time, @Customer, @Discount, @FullPrice)";
    SqlCommand cmd = new SqlCommand(stmt, cn);
    // Adding parameters to the insert statement:
    cmd.Parameters.AddWithValue("@Price", price);
    cmd.Parameters.AddWithValue("@User", user);
    cmd.Parameters.AddWithValue("@Time", time);
    cmd.Parameters.AddWithValue("@Customer", customer);
    cmd.Parameters.AddWithValue("@Discount", discount);
    cmd.Parameters.AddWithValue("@FullPrice", fullprice);
    // Start a transaction so we can roll back if there's an error:
    SqlTransaction transaction = cn.BeginTransaction();
    try {
        cmd.ExecuteNonQuery();
        transaction.Commit();
    } catch (SqlException ex) {
        transaction.Rollback();
        Console.WriteLine(ex.Message);
    } finally {
        cn.Close();
    }
