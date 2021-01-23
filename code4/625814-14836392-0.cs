                // collect relevant inputs
                foreach (Control c in fPanelIn.Controls)
                {
                    if (c.Tag is PropertyInfo) 
                    {
                        PropertyInfo pi = c.Tag as PropertyInfo;
                        if(c.Text.Length>0)
                        {
                            Type ti = pi.PropertyType;
                            if (ti.IsGenericType)
                            {
                                ti = ti.GetGenericArguments()[0];
                            }
                            object o = Convert.ChangeType(c.Text, ti);
                            pi.SetValue(Calculator, o, null);
                            //MethodInfo mi = calcType.GetMethod(ConstructMethodName(pi), new Type[] { typeof(String) });
                            //mi.Invoke(Calculator, new object[] { c.Text });
                        }
                        else
                        {
                            pi.SetValue(Calculator, null, null);
                        }
                    }
                }
