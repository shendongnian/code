    using (var reader = new StreamReader("bla.txt"))
    {
        //create your table string
        var tableString = string.Format("<table>{0}</table>", reader.ReadToEnd());
        //use a literal control to display the table on the page
        pnlContainer.Controls.Add(new LiteralControl(tableString));
    }
