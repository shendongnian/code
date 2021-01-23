    using (var con = new SqlConnection("Server=(local);Integrated Security=True;"))
    {
        con.Open();
        try
        {
            var sqc = new SqlCommand("WAITFOR DELAY '1:00:00'", con);
            var readThread = Task.Run(() => sqc.ExecuteNonQuery());
            // cancel after 5 seconds
            Thread.Sleep(5000);
            sqc.Cancel();
            // this should throw
            await readThread;
            // unreachable
            Console.WriteLine("Succeeded");
        }
        catch (SqlException ex) when (ex.Number == 0 && ex.State == 0 && ex.Class == 11 
            && ex.Message.Contains("Operation cancelled by user."))
        {
            Console.WriteLine("Cancelled");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error");
        }
    }
