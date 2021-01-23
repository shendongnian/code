    protected void printButton_Click(object sender, EventArgs e)
    {
        _printString = "Harry Potter";
        Response.Clear();
        Response.Write(_printString);
        Response.Flush();
        Response.End();
    }
