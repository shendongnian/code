    namespace DelegatesSample
    {
        public delegate void privateCallbackDelegate(string param1, int param2);
        public class A
        {
            private void DelegatedMehod(string param1, int param2)
            {
                //Code for some action
            }
        
            private void CallBusinessClass()
            {
                privateCallBackDelegate del = new privateCallBackDelegate(DelegateMethod);
        
                B b = new B();
                b.InvokeBusinessMethod(del);
            }
        }
        
        public class B
        {        
            public void InvokeBusinessMethod(privateCallbackDelegate d)
            {
                //Do Some calculations and when finished, call the callback delegate
                d("Done", result); //or d.Invoke or d.BeginInvoke
            }
        
        }
    }
