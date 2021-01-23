    private void button1_Click(object sender, RoutedEventArgs e){
      var sb = new StringBuilder();
      sb.Append("Network available:  ");
      sb.AppendLine(DeviceNetworkInformation.IsNetworkAvailable.ToString());
      sb.Append("Cellular enabled:  ");
      sb.AppendLine(DeviceNetworkInformation.IsCellularDataEnabled.ToString());
      sb.Append("Roaming enabled:  ");
      sb.AppendLine(DeviceNetworkInformation.IsCellularDataRoamingEnabled.ToString());
      sb.Append("Wi-Fi enabled:  ");
      sb.AppendLine(DeviceNetworkInformation.IsWiFiEnabled.ToString());
      MessageBox.Show(sb.ToString());}
