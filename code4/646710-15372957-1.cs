    var canAccessDB = false;
    try
    {
        conn.Open();
        canAccessDB = true; // Will only get here if Open() is successful
    }
    catch
    {
        // nothing needed here
    }
    finally
    {
        if (conn != null)
            conn.Dispose(); // Safely clean up conn
    }
    if (!canAccessDB)
    {
        label1.Visible = true;
        label1.Text = "Failed to Access Database! Please log into VPN Using The Link Below.";
    }
    else
    {
        this.Hide();
    }
    Form1 form = new Form1();
    form.Show();
