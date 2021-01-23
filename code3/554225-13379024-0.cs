    public static void InvokeIfRequired(this Form c, Action<Form> action)
            {
                if (c.InvokeRequired)
                {
                    try { c.Invoke(new Action(() => action(c))); }
                    catch { }
                }
                else
                {
                    action(c);
                }
            }
