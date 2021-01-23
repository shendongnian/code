        public static void Enable(this Control con, bool enable)
        {
            if (con != null)
            {
                if (enable)
                {
                    Control original = con;
                    List<Control> parents = new List<Control>();
                    do
                    {
                        parents.Add(con);
                        if (con.Parent != null)
                            con = con.Parent;
                    } while (con.Parent != null && con.Parent.Enabled == false);
                    if (con.Enabled == false)
                        parents.Add(con); // added last control without parent
                    for (int x = parents.Count - 1; x >= 0; x--)
                    {
                        parents[x].Enabled = enable;
                    }
                    con = original;
                    parents = null;
                }
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
