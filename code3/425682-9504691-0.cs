If it's OK for you to use Reflection in this case, you can dig into the private properties and extract their values. Here is an example (based on the Microsoft.Data.ConnectionUI.Sample project from your link):
    static void Main(string[] args)
    {
        DataConnectionDialog dialog = new DataConnectionDialog();
        DataConnectionConfiguration connectionConfig = new DataConnectionConfiguration(null);
        connectionConfig.LoadConfiguration(dialog);
        if (DataConnectionDialog.Show(dialog) == DialogResult.OK)
        {
            bool isSavePasswordChecked = IsSavePasswordChecked(dialog);
        }
    }
    private static bool IsSavePasswordChecked(DataConnectionDialog dialog)
    {
        var control = GetPropertyValue("ConnectionUIControl", dialog, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty);
        if (control == null)
        {
            return false;
        }
        var properties = GetPropertyValue("Properties", control, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.DeclaredOnly);
        if (properties == null)
        {
            return false;
        }
        var savePassword = GetPropertyValue("SavePassword", properties, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
        if (savePassword != null && savePassword is bool)
        {
            return (bool)savePassword;
        }
        return false;
    }
    private static object GetPropertyValue(string propertyName, object target, BindingFlags bindingFlags)
    {
        var propertyInfo = target.GetType().GetProperty(propertyName, bindingFlags);
        if (propertyInfo == null)
        {
            return null;
        }
        return propertyInfo.GetValue(target, null);
    }
