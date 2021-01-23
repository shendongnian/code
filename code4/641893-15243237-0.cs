    public async Task<bool> checkLamp(int iLamp)
    {
        Phone.ButtonIDConstants btn = new Phone.ButtonIDConstants();
        btn = Phone.ButtonIDConstants.BUTTON_1;
        btn += iLamp;
        var tcs = new TaskCompletionSource<bool>();
        var handler = (sender, e) => {
            Phone.OnGetLampModeResponse -= handler;
            var test = e.getLampModeList[0].getLampMode.ToString();
            tcs.SetResult(true);
        };
        Phone.OnGetLampModeResponse += handler;
        Phone.GetLampMode(btn, null);
    
        return tcs.Task;
    }
