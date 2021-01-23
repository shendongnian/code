    public class ErrLog
    {
        public int RowNum;
        public List<string> Messages;
        public ErrLog(int row)
            : base()
        {
            RowNum = row;
        }
        public ErrLog()
        {
            Messages = new List<string>();
        }
    }
