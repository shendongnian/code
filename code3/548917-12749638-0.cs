    class Form1
    {
        public Form1()
        {
             this.Histograms = new List<long[]>();
        }
        public List<long[]> Histograms { get; private set; }
    }
    long[] histogramValues = Form1.GetHistogram(bitmap);
    Form1.Histograms.Add(histogramValues);
