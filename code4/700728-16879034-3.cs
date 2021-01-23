    // the using statement will call your dispose method
    using (var conn = new MySqlConnection(connectionString))
    {
        // open the connection and start the transaction
        conn.Open();
        var transaction = conn.BeginTransaction();
        // createa  list to temporarily store the ids
        List<string> moves = new List<string>();
        try
        {
            // clean the list, do the trim and get everything that's not null or empty
            var cleanList = list.Select(obj => obj.ToString().Split(',')[0].Trim()).Where(s => !string.IsNullOrEmpty(s));
            // loop over the clean list
            foreach (string id in cleanList)
            {
                // add the id to the move list
                moves.Add("'" + id + "'");
                // batch 100 at a time
                if (moves.Count % 100 == 0)
                {
                    // when I reach 100 execute them and clear the list out
                    MoveItems(conn, moves);
                    moves.Clear();
                }
            }
            // The list count might not be n (mod 100) therefore see if there's anything left
            if (moves.Count > 0)
            {
                MoveItems(conn, moves);
                moves.Clear();
            }
            // wohoo! commit the transaction
            transaction.Commit();
        }
        catch (MySqlException ex)
        {
            // oops!  something happened roll back everything
            transaction.Rollback();
            Console.WriteLine(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
