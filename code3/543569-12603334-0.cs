        private void button1_Click(object sender, EventArgs e)
        {
           // foreach (String file in Directory.GetFiles("c:\\windows", "*.dll"))
            String file = @"C:\Windows\Microsoft.NET\Framework64\v2.0.50727\System.Data.dll";
            {
                try
                {
                    //System.Reflection.Assembly.ReflectionOnlyLoadFrom(file);
                    System.Reflection.Assembly.LoadFrom(file);
                }
                catch (Exception ee)
                {
                    textBox1.Text += ee.Message + Environment.NewLine;
                }
            }
        }
