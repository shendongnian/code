    [Serializable]
    public class CoolTimerWhatIWantToSerializeButForWhat
    {
        public double LocalInterval { get; set; }
        public void SaveSomePropertiesOfTimer(System.Timers.Timer iWannaIt)
        {
            //save to local properties properties of iWannaIt
            LocalInterval = iWannaIt.Interval;
        }
        public System.Timers.Timer GetItBackNOW()
        {
            return new System.Timers.Timer(LocalInterval);
        }
    }
