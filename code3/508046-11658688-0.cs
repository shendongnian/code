    public void TestConnectionThread(String connstr_to_test)
    {
        // Notify the user that we're doing our test
        string message = "Testing...";
        lblTestResultMessage.SetPropertyThreadSafe(() => lblTestResultMessage.Text, message);
        try {
            dbTool = new DBTool();
            message = dbTool.connectToDB();
        // If something failed, show a useful debugging message
        } catch (Exception ex) {
            message = ex.ToString();
        }
        // Use a lambda expression to communicate results to the user safely
        lblTestResultMessage.SetPropertyThreadSafe(() => lblTestResultMessage.Text, message);
    }
