    public class MyBool
    {
        bool Value;
        public MyBool(bool value)
        {
            this.Value = value;
        }
        public static MyBool operator ++(MyBool myBoolean)
        {
            myBoolean.Value = !myBoolean.Value;
            return myBoolean;
        }
    }
