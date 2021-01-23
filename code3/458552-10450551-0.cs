    public class TimingController  
    {  
        // Get singleton of Measurement Class  
        Measurement Measure = Measurement.GetInstance();         
        bool isMeasuring = false;
        public SystemClock ClockInstance  
        {  
            get { return Clock; }  
            set { Clock = value; }  
        }  
  
        private void Measuring()  
        {  
            if(isMeasuring) return;
            isMeasuring = true;
            CurrentVoltage = Measure.GetVoltage();  
            CurrentCurrent = Measure.GetCurrent();  
            isMeasuring = false;
        }  
    } 
