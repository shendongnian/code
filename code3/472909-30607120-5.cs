    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.ComponentModel;
    using System.Globalization;
    namespace RegVersionParse
    {
        [ValueConversion(typeof(Version), typeof(string))]
        public class VersionConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null) { return "Not A Version"; }
                return value.ToString();
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return DependencyProperty.UnsetValue;
            }
        }
        /// <summary>Interaction logic for MainWindow.xaml</summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            string myInput;
            public string MyInputVersion
            {
                get { return myInput; }
                set
                {
                    if (myInput != value)
                    {
                        myInput = value;
                        MyOutput = RegDwordIntegerVersionParse(value);               
                        RaisePropertyChanged();
                    }
                }
            }
            Version myOutput;
            public Version MyOutput
            {
                get { return myOutput; }
                set { if (myOutput != value) { myOutput = value; RaisePropertyChanged(); } }
            }
            Brush statusColor;
            public Brush StatusColor
            {
                get { return statusColor; }
                set { if (statusColor != value) { statusColor = value; RaisePropertyChanged(); } }
            }
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                StatusColor = new SolidColorBrush(Colors.Green);
            }
            /// <summary>
            /// This function is designed specifically for producing a 
            /// System.Version object from the Uninstall information
            /// ("Version" key) in the Windows registry for a given app.
            /// </summary>
            /// <param name="input">Using the Registry class to obtain a 
            /// REG_DWORD value for an installed application, 
            /// Input the integer value as a string.</param>
            /// <returns>System Version Object (Major, Minor, Build) </returns>
            public System.Version RegDwordIntegerVersionParse(string input)
            {
                string HexMajor = string.Empty;
                string HexMinor = string.Empty;
                string HexBuild = string.Empty;
                int Major = -1;
                int Minor = -1;
                int Build = -1;
                try
                {
                    //int numVersion = int.Parse(input);
                    Int64 numVersion = Int64.Parse(input); 
                
                    string hexVersion = numVersion.ToString("X8");
                    // Could also check for alphanumeric...
                    if (!string.IsNullOrEmpty(hexVersion) && hexVersion.Length >= 5)
                    {
                        HexMajor = hexVersion.Substring(0, 2);
                        HexMinor = hexVersion.Substring(2, 2);
                        // The Build number could be up to 4 characters, but might be less!
                        HexBuild = hexVersion.Substring(4, hexVersion.Length - 4);
                        Major = int.Parse(HexMajor, System.Globalization.NumberStyles.HexNumber);
                        Minor = int.Parse(HexMinor, System.Globalization.NumberStyles.HexNumber);
                        Build = int.Parse(HexBuild, System.Globalization.NumberStyles.HexNumber);
                        StatusColor = new SolidColorBrush(Colors.White);
                        return new Version(Major, Minor, Build);
                    } 
                    else 
                    {
                        StatusColor = new SolidColorBrush(Colors.Orange);
                        return new Version();
                    }
                }
                catch
                {
                    StatusColor = new SolidColorBrush(Colors.Red);
                    return new Version();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
