    using Microsoft.WindowsMobile.Status;
    BatteryLevel _batteryLevel;
    BatteryState _batteryState;
    void Mobile5_Load(object sender, EventArgs e) {
      _batteryLevel = (BatteryLevel)SystemState.GetValue(SystemProperty.PowerBatteryStrength);
      _batteryState = (BatteryState)SystemState.GetValue(SystemProperty.PowerBatteryState);
      if (!BatteryCritical(false)) {
        // Continue
      }
    }
    /// <summary>
    /// Sets the Battery Level and Battery State for the Mobile Device
    /// <para><value>showDialog=True show the dialog box</value></para>
    /// <para><value>Returns True <b>if</b> the battery is in a critical state</value></para>
    /// </summary>
    /// <param name="showDialog">Do you want a dialog box to be displayed or not?</param>
    /// <returns>false if the Battery is NOT in the critical state</returns>
    bool BatteryCritical(bool showDialog) {
      _batteryAlert = false;
      bool bad = false; // everything starts out ok. We are actually running, after all.
      _batteryLevel = (BatteryLevel)SystemState.GetValue(SystemProperty.PowerBatteryStrength);
      _batteryState = (BatteryState)SystemState.GetValue(SystemProperty.PowerBatteryState);
      bool present = ((_batteryState & BatteryState.NotPresent) != BatteryState.NotPresent);
      bool charging = ((_batteryState & BatteryState.Charging) == BatteryState.Charging);
      bool critical = ((_batteryState & BatteryState.Critical) == BatteryState.Critical);
      bool lowbatry = ((_batteryState & BatteryState.Low) == BatteryState.Low);
      Color c;
      if (present) {
        if (charging) {
          c = Color.Cyan;
        } else {
          if (critical) {
            c = Color.Orange;
            _batteryAlert = true;
          } else if (lowbatry) {
            c = Color.Yellow;
            _batteryAlert = true;
          } else {
            c = Color.White;
          }
        }
      } else {
        c = Color.Silver;
      }
      StatusPanel.BackColor = c;
      switch (_batteryLevel) {
        case BatteryLevel.VeryHigh: // (81-100%)
          BatteryPanel.BackColor = Color.Cyan;
          break;
        case BatteryLevel.High: // (61-80%)
          BatteryPanel.BackColor = Color.Lime;
          break;
        case BatteryLevel.Medium: // 41-60%)
          BatteryPanel.BackColor = Color.Yellow;
          break;
        case BatteryLevel.Low: // (21-40%)
          BatteryPanel.BackColor = Color.Orange;
          //WirelessUpdate(RadioState.Off, false);
          break;
        case BatteryLevel.VeryLow: // (0-20%)
          BatteryPanel.BackColor = Color.Red;
          //WirelessUpdate(RadioState.Off, false);
          bad = (!charging && present);
          break;
      }
      if (showDialog) {
        string msg = string.Format("Level is {0}\r\nState is {1}", _batteryLevel, _batteryState);
        if (_batteryLevel == BatteryLevel.Low) {
          msg += "\r\n\r\nThe wireless radio will be inactive until it has been charged.";
        } else if (bad == true) {
          msg += "\r\n\r\nThis Application will now close to preserve the device. Please return it to a charging base immediately.";
        }
        MessageBox.Show(msg, "Battery Meter", MessageBoxButtons.OKCancel, MessageBoxIcon.None, 0);
      }
      if (!bad) {
        StatusPanel.Refresh();
        // You could signal your app here
      } else {
        // Tell your app this device needs to turn off now.
      }
      return bad;
    }
