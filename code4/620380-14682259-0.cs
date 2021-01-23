    public class CmdTranslateUI : ICommand
    {
        bool ICommand.CanExecute(object parameter)
        {
            CultureInfo ci = new CultureInfo((string)parameter);
            foreach (CultureInfo c in ResxLocalizationProvider.Instance.AvailableCultures)
            {
                if (ci.Name == c.Name)
                    return true;
                else if (ci.Parent.Name == c.Name)
                    return true;
            }
            return false;
        }
        public event EventHandler CanExecuteChanged;
        void ICommand.Execute(object parameter)
        {
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = new CultureInfo(
                (string) parameter);
        }
    }
