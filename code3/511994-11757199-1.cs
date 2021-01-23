       public static void Update<T>(T original, T updated)
       {
           var properties = typeof(T).GetProperties();
           for (var i = 0; i < properties.Length; i++)
           {
               var oldval = properties[i].GetValue(original, null);
               var newval = properties[i].GetValue(updated, null);
               if (!Equals(oldval,newval))
                   properties[i].SetValue(original, newval, null);
           }
       }
