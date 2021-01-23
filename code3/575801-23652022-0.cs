    public static class GuiExtensionMethods
    {
            public static void Enable(this Control con, bool enable)
            {
                if (con != null)
                {
                    foreach (Control c in con.Controls)
                    {
                        c.Enable(enable);
                    }
    
                    try
                    {
                        con.Invoke((MethodInvoker)(() => con.Enabled = enable));
                    }
                    catch
                    {
                    }
                }
            }
    }
