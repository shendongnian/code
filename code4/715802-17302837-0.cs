    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    namespace BackgroundWorkerExample
    {
    public class Program
    {
        private event EventHandler<EventArgs<List<SSS.ServicesConfig.data.Reading>>> ReadingAvailable;
        protected virtual void OnReadingAvailable(List<SSS.ServicesConfig.data.Reading> list)
        {
            EventHandler<EventArgs<List<SSS.ServicesConfig.data.Reading>>> handler = ReadingAvailable;
            if (handler != null)
            {
                handler(this, new EventArgs<List<SSS.ServicesConfig.data.Reading>> (list) );
            }
        }
        private BackgroundWorker bw = new BackgroundWorker();
        void Main(string[] args)
        {
            this.ReadingAvailable +=Program_ReadingAvailable;
            bw.DoWork +=bw_DoWork;
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
        private void Program_ReadingAvailable(object sender, EventArgs<List<SSS.ServicesConfig.data.Reading>> e)
        {
            List<SSS.ServicesConfig.data.Reading> list = e.Value;
            // for each item in the list do something.
            foreach (var reading in list)
            {
                Logging.Log("Starting ProcessGpsFile.ProcessReading 3", "ProcessReading", Apps.RemoteTruckService);
                var gpsreading = new TruckGpsReading();
                gpsreading.DateTimeOfReading = reading.DateTimeOfReading;
                gpsreading.Direction = reading.Direction;
                gpsreading.DriverNumber = CurrentIniSettings.DriverNumber;
                gpsreading.Latitude = (float)reading.Latitude;
                gpsreading.Longitude = (float)reading.Longitude;
                gpsreading.Speed = reading.Speed;
                gpsreading.TruckNumber = CurrentIniSettings.TruckNumber;
                gpsreadings.Add(gpsreading);
            }
            var response = client.SaveGpsReadings(globalSetting.TokenId, globalSetting.SourceId, gpsreadings.ToArray());
            if (response != "true")
            {
                Logging.Log("ProcessGpsFile.ProcessReading: " + response, "ProcessReading", Apps.RemoteTruckService);
            }
            else
            {
                Logging.Log("ProcessGpsFile.ProcessReading: Reading.DeleteGpsReadings(readings)", "ProcessReading", Apps.RemoteTruckService);
                SSS.ServicesConfig.data.Reading.DeleteGpsReadings(readings);
            }
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // if there is something to read
            IEnumerable<SSS.ServicesConfig.data.Reading> readings = Reading.GetUnProcessReadings().ToList();
            if (readings.Count() > 0)
            {
                OnReadingAvailable(readings);
            }
        }
    }
    public class EventArgs<T> : EventArgs
    {
        private readonly T m_value;
        protected EventArgs()
            : base()
        {
            m_value = default(T);
        }
        public EventArgs(T value)
        {
            m_value = value;
        }
        public T Value
        {
            get { return m_value; }
        }
    }
    }
