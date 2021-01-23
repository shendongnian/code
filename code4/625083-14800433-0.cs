    public class ClassA
        {
            private void SomeMethod(out IEnumerable<string> result)
            {
                string[] res;
                SomeMethod(out res);
                result = res;
            }
    
            public void SomeMethod(out string[] someArray)
            {
                someArray = new string[2];
            }
    
            void Test()
            {
                IEnumerable<string> result;
                SomeMethod(out result);
            }
        }
