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
            private List<Tuple<string, string, char>> _transitions = new List<Tuple<string, string, char>>();
    
            public MainViewModel()
            {
                Transitions.Add(new Tuple<string,string,char>("First Item 1","Second Item 1",'A'));
                Transitions.Add(new Tuple<string, string, char>("First Item 2", "Second Item 2", 'B'));
                Transitions.Add(new Tuple<string, string, char>("First Item 3", "Second Item 3", 'C'));
                Transitions.Add(new Tuple<string, string, char>("First Item 4", "Second Item 4", 'D'));
            }
            public List<Tuple<string, string, char>> Transitions
            {
                get { return _transitions; }
                set
                {
                    _transitions = value;
                }
            }        
        }
    }
