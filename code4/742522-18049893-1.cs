    using System;
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
    using System.Windows.Shapes;
    
    namespace TravianResourceProd
    {
        /// <summary>
        /// Interaction logic for PathBuilding.xaml
        /// </summary>
        public partial class PathBuilding : Window
        {
            public PathBuilding()
            {
                InitializeComponent();
                _ConnectorLine = new Line();
                _ConnectorLine.Stroke = new SolidColorBrush(Colors.DarkBlue);
                _ConnectorLine.Visibility = System.Windows.Visibility.Hidden;
                _locationSelector = new LocationOptions();
                _locationSelector.Visibility = System.Windows.Visibility.Hidden;
                DrawCanvas.Children.Add(_ConnectorLine);
                DrawCanvas.Children.Add(_locationSelector);
    
            }
    
            private Line _ConnectorLine;
            private bool _AddMode = false;
    
    
            private LocationOptions _locationSelector;
    
            private void ActiveLocation_Loaded(object sender, RoutedEventArgs e)
            {
                primarySegment.btnAddSegment.Click += (object sender1, RoutedEventArgs e1) =>
                {
                    //show the type selector
                    _locationSelector.Visibility = System.Windows.Visibility.Visible;
                    var loc = _locationSelector.TransformToAncestor(drawingGrid)
                              .Transform(new Point(0, 0));
                    Canvas.SetLeft(_locationSelector, Mouse.GetPosition(DrawCanvas).X + 80);
                    Canvas.SetTop(_locationSelector, Mouse.GetPosition(DrawCanvas).Y - 50);
                     
                };
                _locationSelector.btnTypeOne.Click += (object s, RoutedEventArgs e2) =>
                {
                    _AddMode = true;
                    _ConnectorLine.Visibility = System.Windows.Visibility.Visible;
                    _locationSelector.Visibility = System.Windows.Visibility.Hidden;
                };
            }
             
            private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
            {
                if (!_AddMode)
                    return;
                _AddMode = false;
                _ConnectorLine.Visibility = System.Windows.Visibility.Hidden;
    
                //Add the one we picked
                var oldLoc = new OldLocation();
                Canvas.SetLeft(oldLoc, Canvas.GetLeft(primarySegment));
                Canvas.SetTop(oldLoc, Canvas.GetTop(primarySegment));
                DrawCanvas.Children.Add(oldLoc);
    
                //Add a line connecting old to new
                var newestLine = new Line();
                newestLine.Visibility = System.Windows.Visibility.Visible;
    
                newestLine.Stroke = new SolidColorBrush(Colors.Brown);
    
                newestLine.X1 = _ConnectorLine.X1;
                newestLine.Y1 = _ConnectorLine.Y1;
                newestLine.X2 = _ConnectorLine.X2 + 40;
                newestLine.Y2 = _ConnectorLine.Y2 + 50;
                DrawCanvas.Children.Add(newestLine);
    
                //Move the active/primary to the new location
                Canvas.SetLeft(primarySegment, e.GetPosition(this).X);
                Canvas.SetTop(primarySegment, e.GetPosition(this).Y);
    
            }
    
            private void DrawCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                try
                {//reposition the line going from active location to mouse
                    _ConnectorLine.X1 = Canvas.GetLeft(primarySegment) + 70;
                    _ConnectorLine.Y1 = Canvas.GetTop(primarySegment) + 50;
                    _ConnectorLine.X2 = e.GetPosition(this).X - 5;
                    _ConnectorLine.Y2 = e.GetPosition(this).Y - 5;
                }
                catch (Exception)
                {
                }
            }
        }
    }
