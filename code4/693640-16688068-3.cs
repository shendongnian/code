    using System.Windows;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System;
    namespace TestWPFApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MainViewModel();
            }
        }
    
        public class MainViewModel
        {
            private List<Tuple<string, string, char>> _trasitions = new List<Tuple<string, string, char>>();
    
            public MainViewModel()
            {
                Trasitions.Add(new Tuple<string,string,char>("First Item 1","Second Item 1",'A'));
                Trasitions.Add(new Tuple<string, string, char>("First Item 2", "Second Item 2", 'B'));
                Trasitions.Add(new Tuple<string, string, char>("First Item 3", "Second Item 3", 'C'));
                Trasitions.Add(new Tuple<string, string, char>("First Item 4", "Second Item 4", 'D'));
            }
            public List<Tuple<string, string, char>> Trasitions
            {
                get { return _trasitions; }
                set
                {
                    _trasitions = value;
                }
            }        
        }
    }
