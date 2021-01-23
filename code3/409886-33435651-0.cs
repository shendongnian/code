    public class MyParcelable : Object, IParcelable
    {
        public string MyString { get; set; }
        [ExportField("CREATOR")]
        public static MyParcelableCreator InititalizeCreator()
        {
            return new MyParcelableCreator();
        }
        public MyParcelable(string myString)
        {
            MyString = myString;
        }
        public int DescribeContents()
        {
            return 0;
        }
        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteString(MyString);
        }
        public class MyParcelableCreator : Object, IParcelableCreator
        {
            public Object CreateFromParcel(Parcel source)
            {
                return new MyParcelable(source.ReadString());
            }
            public Object[] NewArray(int size)
            {
                return new MyParcelable[size];
            }
        }
    }
