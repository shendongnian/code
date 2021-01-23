    public class Harvest_TimeSheetEntry
    {
        public bool DirtyFlag {get; private set;}
        
        public void Reset()
        {
            DirtyFlag = false;
        }
        public DateTime StartValue
        {
            get { return _startValue; }
            set 
            {
                _startValue = value;
                // in each of the modifyable Properties add this
                DirtyFlag = true;
            }
        }
        (...)
    }
