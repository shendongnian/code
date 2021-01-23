    internal static class ExtensionMethods
    {
        internal static object Invoke<TControl>(this TControl control,
            string methodName, params object[] parameters)
            where TControl : Control
        {
            object result;
            if (control == null)
                throw new ArgumentNullException("control");
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException("methodName");
            if (control.InvokeRequired)
                result = control.Invoke(new MethodInvoker(() => Invoke(control,
                    methodName, parameters)));
            else
            {
                MethodInfo mi = null;
                if (parameters != null && parameters.Length > 0)
                {
                    Type[] types = new Type[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i] != null)
                            types[i] = parameters[i].GetType();
                    }
                    mi = control.GetType().GetMethod(methodName,
                        BindingFlags.Instance | BindingFlags.Public,
                        null,  types, null);
                }
                else
                    mi = control.GetType().GetMethod(methodName,
                        BindingFlags.Instance | BindingFlags.Public);
                if (mi == null)
                    throw new InvalidOperationException(methodName);
                result = mi.Invoke(control, parameters);
            }
            return result;
        }
