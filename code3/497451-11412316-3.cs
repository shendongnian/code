        private delegate T EndInvokeDelegate<T>(IAsyncResult ar);
        public static void Execute<T, T1>(IAsyncSubscriber subscriber, T param, Func<T, T1> action)
        {
            action.BeginInvoke(param, Callback<T1>, new object[]{subscriber, new new EndInvokeDelegate<T1>(action.EndInvoke)});
        }
        public static void Execute<T, T1, T2>(IAsyncSubscriber subscriber, T param1, T1 param2, Func<T, T1, T2> action)
        {
            action.BeginInvoke(param1, param2, Callback<T2>, new object[]{subscriber, new new EndInvokeDelegate<T2>(action.EndInvoke)});
        }
        private static void Callback<TR>(IAsyncResult ar)
        {
            object[] stateArr = (object[])ar.AsyncState;
            IAsyncSubscriber subscriber = (IAsyncSubscriber)stateArr[0];
            EndInvokeDelegate<TR> action = (EndInvokeDelegate<TR>)stateArray[1];
            TR returnValue = action(ar);
            subscriber.Callback(returnValue);
        }     
