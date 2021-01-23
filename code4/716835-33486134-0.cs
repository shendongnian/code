    using System.Globalization;
    using System.Windows.Input;
     ...
    public static string GetDisplayString(this KeyGesture keyGesture)
    {
        return keyGesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture);
    }
