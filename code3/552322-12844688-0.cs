    public T GetSingleTonForm<T>(object state, Action<T> setParameters)
                where T : FormBase, IFormBase 
            {
                Type t = typeof(T);
                FormBase f = null;
                if (f == null)
                {
                     f = (FormBase)Activator.CreateInstance(t);
                }
    
                if (setParameters != null && f is IFormBase)
                {
                    setParameters.Invoke((T)f);
                }
    
                return (T)f;
            }
