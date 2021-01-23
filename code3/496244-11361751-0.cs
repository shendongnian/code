    namespace Whatever
    {
        enum myEnum
        {
            type1,type2,type3
        }
    
        public class myClass<T>
        {
            public void MyMethod<T>()
            {
                string s = string.Empty;
                foreach (myEnum t in Enum.GetValues(typeof(T)))
                {
                    s += t.ToString();
                }
                MessageBox.Show(s);
            }
        }
        
        public void SomeMethod()
        {
            Test<myEnum> instance = new Test<myEnum>();
            instance.MyMethod<myEnum>(); //wil spam the messagebox with all enums inside
        }
    }
