        internal static TResult GetRemoteProperty<T, TResult>(string Url, System.Linq.Expressions.Expression<Func<T, TResult>> expr)
        {
            T remoteObject = GetRemoteObject<T>(Url);
            System.Exception remoteException = null;
            TimeSpan timeout = TimeSpan.FromSeconds(5);
            System.Threading.Tasks.Task<TResult> t = new System.Threading.Tasks.Task<TResult>(() => 
            {
                try
                {
                    if (expr.Body is System.Linq.Expressions.MemberExpression)
                    {
                        System.Reflection.MemberInfo memberInfo = ((System.Linq.Expressions.MemberExpression)expr.Body).Member;
                        System.Reflection.PropertyInfo propInfo = memberInfo as System.Reflection.PropertyInfo;
                        if (propInfo != null)
                            return (TResult)propInfo.GetValue(remoteObject, null);
                    }
                }
                catch (Exception ex)
                {
                    remoteException = ex;
                }
                return default(TResult);
            });
            t.Start();
            if (t.Wait(timeout))
                return t.Result;
            throw new NotSupportedException();
        }
        internal static T GetRemoteObject<T>(string Url)
        {
            return (T)Activator.GetObject(typeof(T), Url);
        }
