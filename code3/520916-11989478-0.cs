    public struct MyStruct
    {
        public string length
        public string name
    }
    public static MyStruct Values()
    {
        MyStruct result;
        result.name = DAL.Util.getName(ddlID.SelectedValue);
        result.length = DAL.Util.getlength();
        return (result);
    }
