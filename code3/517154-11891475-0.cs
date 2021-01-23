    protected override void Render( HtmlTextWriter writer ) {
        using( HtmlTextWriter htmlwriter = new HtmlTextWriter( new StringWriter() ) ) {
            base.Render( htmlwriter );
            string renderedContent = htmlwriter.InnerWriter.ToString();
            // do something here with the string
            // and/or write it out to the output stream as well
            writer.Write( renderedContent );
        }
    }
