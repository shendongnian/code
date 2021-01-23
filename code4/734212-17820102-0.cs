    const string InputFileName = "test_input.jpg";
    const string OutputFileName = "test_output.jpg";
    var newSize = new Size(640, 480);
    using (var bmpInput = Image.FromFile(InputFileName))
    {
        using (var bmpOutput = new Bitmap(bmpInput, newSize))
        {
            foreach (var id in bmpInput.PropertyIdList)
                bmpOutput.SetPropertyItem(bmpInput.GetPropertyItem(id));
            bmpOutput.SetResolution(300.0f, 300.0f);
            bmpOutput.Save(OutputFileName, ImageFormat.Jpeg);
        }
    }
