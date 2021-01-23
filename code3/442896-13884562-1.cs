        static void AppendTo<T>(this Delegate newDel, ref T baseDel) where T : class
        {
            newDel = (Delegate)(Object)newDel.As<T>();
            T oldBaseDel, newBaseDel;
            do
            {
                oldBaseDel = baseDel;
                newBaseDel = (T)(Object)Delegate.Combine((Delegate)(object)oldBaseDel, newDel);
            } while (System.Threading.Interlocked.CompareExchange(ref baseDel, newBaseDel, oldBaseDel) != oldBaseDel);
        }
        static void SubtractFrom<T>(this Delegate newDel, ref T baseDel) where T : class
        {
            newDel = (Delegate)(Object)newDel.As<T>();
            T oldBaseDel, newBaseDel;
            do
            {
                oldBaseDel = baseDel;
                newBaseDel = (T)(Object)Delegate.Remove((Delegate)(object)oldBaseDel, newDel);
            } while (System.Threading.Interlocked.CompareExchange(ref baseDel, newBaseDel, oldBaseDel) != oldBaseDel);
        }
