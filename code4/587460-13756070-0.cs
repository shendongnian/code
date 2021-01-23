            private void button2_Click(object sender, EventArgs e)
        {
            var radios = Radios.GetRadios();
            radios.Refresh();
            var wifiRadio = (from radio in radios
                   where radio.RadioType == RadioType.WiFi
                   select radio).FirstOrDefault();
            if (wifiRadio != null)
                switch (wifiRadio.RadioState)
                {
                    case RadioState.Off:
                        wifiRadio.RadioState = RadioState.On;
                        button2.Text = "Is On";
                        break;
                    case RadioState.On:
                        wifiRadio.RadioState = RadioState.Off;
                        button2.Text = "Is Off";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }                            
        }
    }
