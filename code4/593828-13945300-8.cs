    public class ErrLog
    {
        public int RowNum;
        public List<string> Err;
        public ErrLog(int row)
            : base()
        {
            RowNum = row;
        }
        public ErrLog()
        {
            Err = new List<string>();
        }
    }
