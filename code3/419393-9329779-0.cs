     while (true)
     {
       waitEvent.WaitOne();
       this.InvokeEx(t => t.posterUniformGrid.Rows = calculatedRows); 
       this.InvokeEx(t => t.posterUniformGird.Columns = calculatedCols);             
     }
     public static class ISynchronizeInvokeExtensions
        {
            public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
            {
                if (@this.InvokeRequired)
                {
                    try
                    {
                        @this.Invoke(action, new object[] { @this });
                    }
                    catch { }
                }
                else
                {
                    action(@this);
                }
            }
        }
