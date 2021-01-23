    public string SomeNumber
{
    get
    {
        return String.Format("{0:#.000}", SomeProfileModel.Instance.SomeProfile.SomeNumber);
    }
    set
    {
        if (SomeProfileModel.Instance.SomeProfile.SomeNumber.ToString() == value) return;
        var oldValue = SomeProfileModel.Instance.SomeProfile.SomeNumber;
        try
        {
            double newValue;
            try
            {
                newValue = Convert.ToDouble(value, CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                newValue = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            }
            if (Convert.ToDouble(MyAppParams.SomeNumberMin, CultureInfo.InvariantCulture) > newValue || Convert.ToDouble(MyAppParams.SomeNumberMax, CultureInfo.InvariantCulture) < newValue)
            {
                // Revert back to previous value
                // NOTE: This has to be done here. If done in the catch statement, 
                // it will never run since the MessageBox interferes with it.
                throw new Exception();
            }
            SomeProfileModel.Instance.SomeProfile.SomeNumber = newValue;
            RaisePropertyChanged("SomeNumber", oldValue, newValue, true);
        }
        catch (Exception err)
        {
            System.Windows.MessageBox.Show("Value must be a number between " + MyAppParams.SomeNumberMin + " and " + MyAppParams.SomeNumberMax);
        }
    }
