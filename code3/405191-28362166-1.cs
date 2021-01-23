    using System.Management;
            String batterystatus;
            PowerStatus pwr = SystemInformation.PowerStatus;
            batterystatus = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
            MessageBox.Show("battery charge status : " + batterystatus);
            String batterylife;
            batterylife = SystemInformation.PowerStatus.BatteryLifePercent.ToString();
            MessageBox.Show(batterylife);
