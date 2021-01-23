    namespace ElementFlowExample
    {
    #region Using Statements:
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Media.Media3D;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using FluidKit.Controls;
    using FluidKit.Showcase.ElementFlow;
    #endregion
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields:
        private StringCollection _dataSource;
        private LayoutBase[] _layouts = {
                                            new Wall(),
                                            new SlideDeck(),
                                            new CoverFlow(),
                                            new Carousel(),
                                            new TimeMachine2(),
                                            new ThreeLane(),
                                            new VForm(),
                                            new TimeMachine(),
                                            new RollerCoaster(),
                                            new Rolodex(),
                                        };
        private Random _randomizer = new Random();
        private int _viewIndex;
        #endregion
        #region Properties:
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _elementFlow.Layout = _layouts[3];
            _currentViewText.Text = _elementFlow.Layout.GetType().Name;
            _selectedIndexSlider.Maximum = _elementFlow.Items.Count - 1;
            _elementFlow.SelectionChanged += EFSelectedIndexChanged;
            _elementFlow.SelectedIndex = 0;
            _dataSource = FindResource("DataSource") as StringCollection;
        }
        private void EFSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine((sender as ElementFlow).SelectedIndex);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                _viewIndex = (_viewIndex + 1) % _layouts.Length;
                _elementFlow.Layout = _layouts[_viewIndex];
                _currentViewText.Text = _elementFlow.Layout.GetType().Name;
            }
        }
        private void ChangeSelectedIndex(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            _elementFlow.SelectedIndex = (int)args.NewValue;
        }
        private void RemoveCard(object sender, RoutedEventArgs args)
        {
            if (_elementFlow.Items.Count > 0)
            {
                _dataSource.RemoveAt(_randomizer.Next(_dataSource.Count));
                // Update selectedindex slider
                _selectedIndexSlider.Maximum = _elementFlow.Items.Count - 1;
            }
        }
        private void AddCard(object sender, RoutedEventArgs args)
        {
            Button b = sender as Button;
            int index = _randomizer.Next(_dataSource.Count);
            if (b.Name == "_regular")
            {
                _dataSource.Insert(index, "Images/01.jpg");
            }
            else
            {
                _dataSource.Insert(index, string.Format("Images/{0:00}", _randomizer.Next(1, 12)) + ".jpg");
            }
            // Update selectedindex slider
            _selectedIndexSlider.Maximum = _elementFlow.Items.Count - 1;
        }
    } // END of Class...
    } // END of Namespace...
