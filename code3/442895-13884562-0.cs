        static T As<T>(this Delegate del) where T : class
        {
            if (del == null || del.GetType() == typeof(T)) return (T)(Object)del;
            Delegate[] invList = ((Delegate)(Object)del).GetInvocationList();
            for (int i = 0; i < invList.Length; i++)
                if (invList[i].GetType() != typeof(T))
                    invList[i] = Delegate.CreateDelegate(typeof(T), invList[i].Target, invList[i].Method);
            return (T)(Object)Delegate.Combine(invList);
        }
