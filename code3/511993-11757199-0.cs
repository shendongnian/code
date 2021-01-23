       public static void Update(object original, object updated)
       {
           var oldProperties = original.GetType().GetProperties();
           var newProperties = updated.GetType().GetProperties();
           for (var i = 0; i < oldProperties.Length; i++)
           {
               var oldval = oldProperties[i].GetValue(original, null);
               var newval = newProperties[i].GetValue(updated, null);
               if (!Equals(oldval,newval))
                   oldProperties[i].SetValue(original, newval, null);
           }
       }
