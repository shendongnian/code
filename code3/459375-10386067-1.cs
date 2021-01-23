    public void ConverIMG(string filename)
    {
        PDFWrapper wrapper = new PDFWrapper();
        wrapper.RenderDPI = Dpi;
        wrapper.LoadPDF(filename);
        int count = wrapper.PageCount;
        for (int i = 1; i <= count; i++)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"IMG\" + i.ToString() + ".png";
            wrapper.ExportJpg(fileName, i, i, (double) 100, 100);
            while (wrapper.IsJpgBusy)
            {
                Thread.Sleep(1);
            }
            if (i % 50 == 0)
            {
                wrapper.Dispose();
                wrapper = new PDFWrapper();
                wrapper.RenderDPI = Dpi;
                wrapper.LoadPDF(filename);
            }
        }
        wrapper.Dispose();
    }
