    public class MyParcelable : IParcelable
    {
        public int DescribeContents()
        {
            throw new NotImplementedException();
        }
        public void WriteToParcel(Parcel dest, int flags)
        {
            throw new NotImplementedException();
        }
        public IntPtr Handle
        {
            get { throw new NotImplementedException(); }
        }
    }
