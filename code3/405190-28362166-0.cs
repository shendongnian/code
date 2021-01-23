    using System.Management;
    String batterystatus;
    powerstatus pwr = SystemInformation.PowerStatus;
    batterystatus = SystemInformation.Powerstatus.BatteryChargestatus.ToString();
    MessageBox.Show("battery charge status : " +batterystatus);
    String batterylife;
    batterylife = SystemInformation.PowerStatus.BatteryLifePercent.ToString();
    MessageBox.Show(batterylife);
