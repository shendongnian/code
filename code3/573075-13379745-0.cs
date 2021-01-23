        void dumpProperties(object target)
        {
            if (target.GetType().IsSimple() || target.GetType().IsMethodImplemented("ToString"))
                System.Diagnostics.Debug.WriteLine(target.ToString());
            else if (target is IEnumerable)
            {
                foreach (object item in (IEnumerable)target)
                {
                    System.Diagnostics.Debug.WriteLine(dumpProperties(target));
                }
            }
            else
            {
                foreach (FieldInfo fieldInfo in target.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    System.Diagnostics.Debug.WriteLine(dumpProperties(fieldInfo.FieldHandle.Value));
                }
                foreach (PropertyInfo propertyInfo in oClass.GetType().GetProperties())
                {
                    System.Diagnostics.Debug.WriteLine(dumpProperties(propertyInfo.GetGetMethod().MethodHandle.Value));
                }
            }
        }
