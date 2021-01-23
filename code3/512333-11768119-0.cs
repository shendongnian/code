    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using OpenHardwareMonitor.Hardware;
    
    namespace WindowsFormsApplication1
    {
        public class MySettings : ISettings
        {
            private IDictionary<string, string> settings = new Dictionary<string, string>();
    
            public MySettings(IDictionary<string, string> settings)
            {
                this.settings = settings;
            }
    
            public bool Contains(string name)
            {
                return settings.ContainsKey(name);
            }
    
            public string GetValue(string name, string value)
            {
                string result;
                if (settings.TryGetValue(name, out result))
                    return result;
                else
                    return value;
            }
    
            public void Remove(string name)
            {
                settings.Remove(name);
            }
    
            public void SetValue(string name, string value)
            {
                settings[name] = value;
            }
        }
    
        public class Form1 : Form
        {
            Computer myComputer;
            Timer timer = new Timer { Enabled = true, Interval = 1000 };
    
            public Form1()
            {
                timer.Tick += new EventHandler(timer_Tick);
    
                MySettings settings = new MySettings(new Dictionary<string, string>
                {
                    { "/intelcpu/0/temperature/0/values", "H4sIAAAAAAAEAOy9B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/Iu6//MH37x79i9/+NX6N3/TJm9/5f/01fw1+fosnv+A/+OlfS37/jZ/s/Lpv9fff6Ml/NTef/yZPnozc5679b+i193//TQZ+/w2Dd+P9/sZeX/67v/GTf/b3iP3u4/ObBL//73+i+f039+D8Zk/+xz/e/P6beu2TQZju8yH8f6OgzcvPv/U3/Rb8+z/0f/9b/+yfaOn8079X6fr6Cws7ln/iHzNwflPv99/wyS/+xY4+v/evcJ+733+jJ5//Cw7/4ndy9Im3+U2e/Fbnrk31C93vrt/fyPvdb+N//hsF7/4/AQAA//9NLZZ8WAIAAA==" },
                    { "/intelcpu/0/load/0/values", "H4sIAAAAAAAEAOy9B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/Iu6//MH37x79i9++mpwcv/md/9df89egZ/xX/ym/5y/4D37618Lv7ya//u+58+u+5d9/z7/5t/w9/6u5fP5bH/6av+eTkXyefXxp26ONaf/v/dG/sf39D/rvnv4e5vc/0IP56/waK/vuHzf5I38P8/tv+mv8Rbb9f0pwTF9/zr/1X9vP/8I//+/6Pf7Z30N+/zdf/HX29zd/859q4aCNP5b//U+U3/+7f+zXOjZwfqvDX/V7/o9/vPz+a1G/pv0f+fGlhfk7eZ//N3/0v28//5X0u/n8Cxq7+f1X/tHft20A5x8a/W5/02+BP36Nf+j/nv8XfzrT+c2//Ob4p3+vktvUhNs/+xcWikP6e/4T/5jS5M8/sL8vP/5ff49f/Ivl9//sHzv6PX/vXyG//9R/94/9HuZ34P/5vyC//3W/5e/1exa/k+Bw4bUBnU2bP4Xg/1bn0uafeTH6PatfKL//N3/0t2y/gG9+/8+IzqYNxmU+/+jwX7afY67/nwAAAP//GYSA31gCAAA=" },
                });
    
                myComputer = new Computer(settings) { CPUEnabled = true };
                myComputer.Open();
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                Trace.WriteLine("");
                foreach (var hardwareItem in myComputer.Hardware)
                {
                    if (hardwareItem.HardwareType == HardwareType.CPU)
                    {
                        hardwareItem.Update();
                        foreach (IHardware subHardware in hardwareItem.SubHardware)
                            subHardware.Update();
    
                        foreach (var sensor in hardwareItem.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature)
                            {
                                Trace.WriteLine(String.Format("{0} Temperature = {1}", sensor.Name, sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value"));
                            }
                        }
                    }
                }
            }
        }
    }
