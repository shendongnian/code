    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    namespace ScratchConsole
    {
        static class Program
        {
            private static void Main(string[] args)
            {
                Test<int>();
            }
            private static void Test<T>()
            {
                var listProperty = typeof(WebserviceUtil).GetProperty("List" + typeof(T).Name);
                var mainList = (ObservableCollection<T>)listProperty.GetValue(WebserviceUtil.Instance, null);
                mainList.CollectionChanged += AllItems_CollectionChanged;
                mainList.Add(default(T));
            }
            private static void AllItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                Debug.WriteLine("AllItems_CollectionChanged was called!");
            }
            private class WebserviceUtil
            {
                public static readonly WebserviceUtil Instance = new WebserviceUtil();
                private WebserviceUtil() { ListInt32 = new ObservableCollection<int>(); }
                public ObservableCollection<int> ListInt32 { get; private set; }
            }
        }
    }
