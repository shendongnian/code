     private void GetFormNames()
            {
               
    
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type t in a.GetTypes())
                    {
                        if (t.IsPublic && t.BaseType == typeof(System.Windows.Forms.Form))
    
                        {
    
                            if (t.FullName != "System.Windows.Forms.PrintPreviewDialog")
                           {
                            //Form f = (Form)Activator.CreateInstance(t);
    
                           var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                            if (emptyCtor != null)
                            {
                                var f = (Form)emptyCtor.Invoke(new object[] { });
                                string FormText = f.Text;
                                string FormName = f.Name;
                                listBox1.Items.Add("" + FormText + "//" + FormName + "");
                            }
                           }
                        
                        }
                    }
    
                }
    
            }
