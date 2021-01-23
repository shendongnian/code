    private void btnOpen_Click(object sender, EventArgs e)
    {
        try
        {
            using (newUser = cls.ImpersonateUser("username", "domain", "password"))
            {
                string fileName = @"\\network_computer\Test\Test.doc";
                System.Diagnostics.Process.Start(fileName);
            }
        }
        catch (Exception ex) { throw ex; }
        finally
        {
            if (newUser != null)
                newUser.Undo();
        }
    }
