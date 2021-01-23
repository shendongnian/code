    protected override void Render( HtmlTextWriter writer ) {
        using( HtmlTextWriter htmlwriter = new HtmlTextWriter( new StringWriter() ) ) {
            base.Render( htmlwriter );
            string renderedContent = htmlwriter.InnerWriter.ToString();
            // do something here with the string, like save to disk
            File.WriteAllText( @"c:\temp\foo.html", renderedContent );
            // you could also Response.BinaryWrite() the data to the client 
            // so that it could be saved on the user's machine.
            // and/or write it out to the output stream as well
            writer.Write( renderedContent );
        }
    }
