    private void setAccentResources()
    {
        var accent = (Color)Current.Resources["PhoneAccentColor"];
        var accent80 = accent;
        var accent60 = accent;
        var accent40 = accent;
        var accent20 = accent;
        accent80.A = (byte)(accent.A * 0.8);
        accent60.A = (byte)(accent.A * 0.6);
        accent40.A = (byte)(accent.A * 0.4);
        accent20.A = (byte)(accent.A * 0.2);
        Resources.Add("PhoneAccentFullColor", new SolidColorBrush(accent));
        Resources.Add("PhoneAccent80Color", new SolidColorBrush(accent80));
        Resources.Add("PhoneAccent60Color", new SolidColorBrush(accent60));
        Resources.Add("PhoneAccent40Color", new SolidColorBrush(accent40));
        Resources.Add("PhoneAccent20Color", new SolidColorBrush(accent20));
    }
