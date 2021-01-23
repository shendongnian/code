    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    using System.Windows.Forms;
    namespace MyNamespace
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass x = new MyClass();
                var com = x.GetCOMs();
                foreach (string port in com) 
                {
                    Console.WriteLine(port);
                }
                Console.ReadLine();
            }
    
        }
    
        class MyClass
        {
            public List<string> GetCOMs()
            {
                List<string> coms = new List<string>();
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
    
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        object captionObj = obj["Caption"];
                        if (captionObj != null)
                        {
                            string caption = captionObj.ToString();
                            if (caption.Contains("(COM"))
                            {
                                coms.Add(caption);
                            }
                        }
                    }
    
                    m_ParseCOMs(ref coms);
                }
                catch (ManagementException ex)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
                    return coms;
                }
    
                return coms;
            }
    
            private void m_ParseCOMs(ref List<string> comPorts)
            {
                string[] temp;
                List<string> temp2 = new List<string>();
                int index = 0;
                foreach (string s in comPorts)
                {
                    string temp3 = "";
                    temp = s.Split(' ');
                    temp3 += temp[temp.Length - 1] + " - ";
                    for (int i = 0; i < temp.Length - 1; i++)
                    {
                        temp3 += temp[i] + " ";
                    }
                    temp2.Insert(index, temp3);
                    index++;
                }
                comPorts = temp2;
            }
        }
    }
