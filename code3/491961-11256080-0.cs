    using (var writer = File.CreateText(saveFc.Filename))
    {
        // store the filename for later use
        UtilityClass.filename = saveFc.Filename;
        // get the text from textview1
        string text = textview1.Buffer.Text;
        // write the text
        writer.Write(text);
    }
