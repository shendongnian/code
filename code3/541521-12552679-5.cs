    public class MyAttr : Attribute
    {
        private string _test;
        public MyAttr(string test)
        {
            this._test = test;
        }
        public string getAttr()
        {
            return _test;
        }
    }
    public class BaseClass
    {
        private string theString;
        public BaseClass()
        {
            StackTrace callStack = new StackTrace();
            for ( int i = 0; i < callStack.FrameCount; i++ )
            {
                Type t = callStack.GetFrame(i).GetMethod().DeclaringType;
                foreach ( MemberInfo m in t.GetMembers().Where(x => typeof(BaseClass).IsAssignableFrom(x.Type)) )
                {
                    foreach ( var z in  m.GetCustomAttributes(typeof(MyAttr)) )
                    {
                        MyAttr theAttr = z as MyAttr;
                        if ( z!= null )
                        {
                            theString = z.getAttr();
                            return;
                        }
                    }
                }
            }
        }
        public string Test
        {
            get { 
                return theString;
            }
        }
    }
