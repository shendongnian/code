    public class BoldGauge
    {
        public BoldGauge(ASPxGaugeControl gauge, string gaugeValue, string gaugeDataType, float gaugeMinValue, float gaugeMaxValue)
        {
            Gauge = gauge;
            GaugeValue = gaugeValue;
            GaugeDataType = gaugeDataType;
            GaugeMinValue = gaugeMinValue;
            GaugeMaxValue = gaugeMaxValue;    
        }
    
        public string GaugeValue { get; set; }
        public int GaugeTimer { get; set; }
        public string GaugeDataType { get; set; }
        public ASPxGaugeControl Gauge { get; set; }
        public float GaugeMinValue { get; set; }
        public float GaugeMaxValue { get; set; }
    }
