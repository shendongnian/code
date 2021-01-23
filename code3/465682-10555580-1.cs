    using (var reader = new StreamReader("bla.txt"))
    {
        //use the object initializer to prepare a new literal control
        var litCtrl = new Literal 
        { 
            Mode = LiteralMode.PassThrough, 
            Text = string.Format("<table>{0}</table>", reader.ReadToEnd()))
        }
        //use a literal control to display the table on the page
        pnlContainer.Controls.Add(litCtrl);
    }
