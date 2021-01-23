    protected void batteryLevel ()
            {
                var filter  = new IntentFilter(Intent.ActionBatteryChanged);
                var battery = RegisterReceiver(null, filter);
                int level   = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                int scale   = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
    
                double level_0_to_100 = Math.Floor (level * 100D / scale);
    
            } 
