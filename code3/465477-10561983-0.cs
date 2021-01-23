    using System.Collections.Generic;
    using Microsoft.Phone.Controls;
    using System.IO;
    using System.IO.IsolatedStorage;
    namespace PhoneApp1
    {
    public partial class Page1 : PhoneApplicationPage
    {
        public static List<string> list = new List<string>();
        public Page1()
        {
            InitializeComponent();
            listBox1.ItemsSource = list;
            IsolatedStorageFile storge = IsolatedStorageFile.GetUserStoreForApplication();
            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream("/list.txt", FileMode.OpenOrCreate, storge));
            for (int i = 0; i < list.Count; i++)
            {
                writer.WriteLine(list[i]);
            }   
            writer.Close();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("content"))
            {
                list.Add(NavigationContext.QueryString["content"]);
            }
            base.OnNavigatedTo(e);
        }
    }
    }
