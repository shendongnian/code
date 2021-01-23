    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<Person> _collection = new ObservableCollection<Person>();
            ScrollViewer scrollView = null;
            ScrollViewer scrollView2 = null;
    
            public MainWindow()
            {
                for (int i = 0; i < 50; i++)
                {
                    var p = new Person() { Name = string.Format("{0}", i), Age = i };
                    _collection.Add(p);
                }
                this.DataContext = this;
                InitializeComponent();
            }
    
            void scrollView_ScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                var newOffset = e.VerticalOffset;
    
                if ((null != scrollView) && (null != scrollView2))
                {
                    scrollView.ScrollToVerticalOffset(newOffset);
                    scrollView2.ScrollToVerticalOffset(newOffset);
                }
            }
    
            public ObservableCollection<Person> Collection
            {
                get
                {
                    return _collection;
                }
            }
    
            private ScrollViewer getScrollbar(DependencyObject dep)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dep); i++)
                {
                    var child = VisualTreeHelper.GetChild(dep, i);
                    if ((null != child) && child is ScrollViewer)
                    {
                        return (ScrollViewer)child;
                    }
                    else
                    {
                        ScrollViewer sub = getScrollbar(child);
                        if (sub != null)
                        {
                            return sub;
                        }
                    }
                }
                return null;
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                scrollView = getScrollbar(dataGrid1);
                scrollView2 = getScrollbar(dataGrid2);
    
                if (null != scrollView)
                {
                    scrollView.ScrollChanged += new ScrollChangedEventHandler(scrollView_ScrollChanged);
                }
                if (null != scrollView2)
                {
                    scrollView2.ScrollChanged += new ScrollChangedEventHandler(scrollView_ScrollChanged);
                }
            }
        }
    
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
