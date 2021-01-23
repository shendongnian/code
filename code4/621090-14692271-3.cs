    using System;
    using Microsoft.Phone.Controls;
    using Newtonsoft.Json;
    
    namespace PhoneApp2
    {
        public partial class Page1 : PhoneApplicationPage
        {
            public Page1()
            {
                InitializeComponent();
            }
    
            protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                var param = Uri.UnescapeDataString(NavigationContext.QueryString["arr"]);
                var arr = JsonConvert.DeserializeObject<string[,]>(param);
            }
        }
    }
