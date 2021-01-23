    // It's okay to keep long-running SQLite connections.
    // In my applications I have a single application-wide connection.
    // The more important thing is watching thread-access and transactions.
    // In any case, we can keep this here.
    SQLiteConnection sqlconnection = new SQLiteConnection(con);
    sqlconnection.Open();
    // In timer event - remember this is on the /UI/ thread.
    // DO NOT ALLOW CROSS-THREAD ACCESS TO THE SAME SQLite CONNECTION.
    // (You have been warned.)
    URL u = firefox.URLs[count2];
    string newtitle = u.title;
    form.label1.Text = count2 + "/" + pBar.Maximum;
    
    try {
       // This transaction is ONLY kept about for this timer callback.
       // Great care must be taken with long-running transactions in SQLite.
       // SQLite does not have good support for (long running) concurrent-writers
       // because it must obtain exclusive file locks.
       // There is no Table/Row locks!
       sqlconnection.BeginTransaction();
       // using ensures cmd will be Disposed as appropriate.
       using (var cmd = sqlconnection.CreateCommand()) {
         // Using placeholders is cleaner. It shouldn't be an issue to
         // re-create the SQLCommand because it can be cached in the adapter/driver
         // (although I could be wrong on this, anyway, it's not "this issue" here).
         cmd.CommandText = "insert or ignore into " + table
           + " (id, url, title, visit_count, typed_count, last_visit_time, hidden)"
           + " values (@dbID, @url, 'etc, add other parameters')";
         // Add each parameter; easy-peasy
         cmd.Parameters.Add("@dbID", dbID);
         cmd.Parameter.Add("@url", u.url);
         // .. add other parameters
         cmd.ExecuteNonQuery();
       }
       // Do same for other command (runs in the same TX)
       // Then commit TX
       sqlconnection.Commit();
    } catch (Exception ex) {
       // Or fail TX and propagate exception ..
       sqlconnection.Rollback();
       throw;
    }
    
    if (pBar.Maximum == count2)
    {
        pBar.Value = 0;
        timer.Stop();
        // All the other SQLite resources are already
        // cleaned up!
        sqlconnection.Dispose();
        sqlconnection.Close();
    }
