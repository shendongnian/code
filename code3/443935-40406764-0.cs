    private void SubmitResponseToPrinter(ILabelRequestResponse response)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender, args) =>
            {
                Image i = Image.FromFile(response.Labels[0].FullPathFileName.Trim());
                args.Graphics.DrawImage(i, args.PageBounds);
            };
            pd.Print();
        }
