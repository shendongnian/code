            FieldInfo anEvn = item.GetType().GetField("OnERCErrorHandler",
               System.Reflection.BindingFlags.Instance |
               System.Reflection.BindingFlags.NonPublic) as FieldInfo;
            if (anEvn != null)
                MulticastDelegate mDel = anEvn.GetValue(item) as MulticastDelegate;
