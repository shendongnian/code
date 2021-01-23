    var box = new RichTextBox();
    var reader = new StreamReader(input);
    box.Rtf = reader.ReadToEnd();
    var writer = new StreamWriter(output);
    writer.Write(box.Text);
    writer.Flush();
