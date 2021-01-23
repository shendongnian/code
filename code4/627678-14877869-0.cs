    public Form1()
    {
      InitializeComponent();
      InitializeChart();
    }
    
    private Bitmap chartBmp;
    
    private void InitializeChart()
    {
      tChart1.Series.Add(new Steema.TeeChart.Styles.Bar()).FillSampleValues();
    
      chartBmp = tChart1.Bitmap;
    
      tChart1.GetLegendRect += tChart1_GetLegendRect;
    }
    
    void tChart1_GetLegendRect(object sender, Steema.TeeChart.GetLegendRectEventArgs e)
    {
      Rectangle cropRect = e.Rectangle;
      Bitmap legendImg = new Bitmap(cropRect.Width, cropRect.Height);
    
      using (Graphics g = Graphics.FromImage(legendImg))
      {
        g.DrawImage(chartBmp, new Rectangle(0, 0, legendImg.Width, legendImg.Height),
                         cropRect,
                         GraphicsUnit.Pixel);
      }
    
      legendImg.Save(@"c:\temp\legend.png");
    }
