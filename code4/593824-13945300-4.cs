    public class MemberInfo
    {
        public string MemberPhone;
        public string MemberName;
        public string MemberAddr1;
        public string MemberAddr2;
        public string MemberCity;
        public string MemberState;
        public string MemberZip;
    }
    public class ErrLog
    {
        public int RowNum;
        public List<string> Err;
        public ErrLog(int row)
        {
            RowNum = row;
            Err = new List<string>();
        }
        public ErrLog()
        {
            Err = new List<string>();
        }
    }
