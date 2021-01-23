                foreach (Process p in Process.GetProcesses())
                {
                    string strName = listBox1.SelectedItem.ToString();
                    if (p.ProcessName == strName)
                    {
                        p.Kill();
                    }
                    listBox1.Items.Remove(strName);
                }
