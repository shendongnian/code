    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        double testVal;
        bool ok = false;
        
        var isText = e.SourceDataObject.GetDataPresent(System.Windows.DataFormats.Text, true);
        if (isText)
        {
            var text = e.SourceDataObject.GetData(DataFormats.Text) as string;
            if (Double.TryParse(text, out testVal))
            {
                ok = true;
            }
        }
        if (!ok)
        {
            e.CancelCommand();
        }
    }
