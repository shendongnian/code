    public class DataTypeOne
    {
        private readonly int mId = 0;
    
        public DataTypeOne(int id)
        {
            mId = id;
        }
    
        public int ID
        {
            get { return mId; }
        }
    
        public override string ToString()
        {
            return String.Format("I am a DataTypeOne with ID {0}", mId.ToString("N"));
        }
    }
