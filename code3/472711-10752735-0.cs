    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using System.IO.IsolatedStorage;
    namespace F5debugWp7IsolatedStorage
    {
       public partial class MainPage : PhoneApplicationPage
       {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings ISSetting = IsolatedStorageSettings.ApplicationSettings;
           if (!ISSetting.Contains("DataKey"))
            {
                ISSetting.Add("DataKey", txtSaveData.Text);
            }
            else
            {
                ISSetting["DataKey"] = txtSaveData.Text;
            }
            ISSetting.Save();
        }
    }
}
