	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using OpenHardwareMonitor;
	using OpenHardwareMonitor.Hardware;
	namespace CPUTemperatureMonitor
	{
		public partial class Form1 : Form
		{
			Computer thisComputer;
			public Form1()
			{
				
				InitializeComponent();
				thisComputer = new Computer() { CPUEnabled = true };
				
				thisComputer.Open();
			}
			private void timer1_Tick(object sender, EventArgs e)
			{
				String temp = "";
				foreach (var hardwareItem in thisComputer.Hardware)
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
								
								temp += String.Format("{0} Temperature = {1}\r\n", sensor.Name, sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
								
							}
						}
					}
				}
				textBox1.Text = temp;
			
			}
		}
	}
