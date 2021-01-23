    public void RunMethodOn(object obj, String methodName,params Object[] args)
            {
                if(obj != null)
                {
                    System.Reflection.MethodInfo method = null;
                    method = obj.GetType().GetMethod(methodName);
                    if (method != null)
                        method.Invoke(obj, args);
                }
            }
           
