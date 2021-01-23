    class Sample
    {
        int SampleValueX,  SampleValueY;
        string SampleFacing;
        public Sample(XSetting xSetting)
        {
            SampleValueX = xSetting.X;
            SampleValueY = 0;
            SampleFacing = xSetting.SampleFacing;
        }
        public Sample(YSetting ySetting)
        {
            SampleValueX = 0;
            SampleValueY = ySetting.Y;
            SampleFacing = ySetting.SampleFacing;
        }
    }
    public class XSetting
    {
        public int X { get; set; }
        public string SampleFacing { get; set; }
    }
    public class YSetting
    {
        public int Y { get; set; }
        public string SampleFacing { get; set; }
    }
