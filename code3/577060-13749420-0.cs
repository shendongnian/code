    try
    {
        var data = Clipboard.GetDataObject();
        var stream = (System.IO.Stream)data.GetData(DataFormats.CommaSeparatedValue);
        var enc = new System.Text.UTF8Encoding();
        var reader = new System.IO.StreamReader(stream, enc);
        string data_csv = reader.ReadToEnd();
        string[] data_csv_array = data_csv.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        ...
    }
    catch (Exception e)
    {
        ErrorHandling.ShowError("There is no data on the Clipboard to paste.");=
    }
