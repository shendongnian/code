    public MainPage()
            {
                InitializeComponent();
                double[] lattitudes = { 50.21934078740, 33.563511, 19.511719, 25.3125 };
                double[] longitudes = { 23.0518068854053, 35.368259, -14.43468, 67.542167 };
                this.DrawPolyLine(lattitudes, longitudes);   
                
            }
    
                private void DrawPolyLine(double []lat, double[]longi)
            {
                
                MapPolyline line = new MapPolyline();
                 line.Stroke = new SolidColorBrush(Colors.Brown);
                line.StrokeThickness = 3;
                line.Locations = new LocationCollection();
                for (int i=0;i<4;i++){
                    line.Locations.Add(new Location(lat[i], longi[i]));
                    
                    Pushpin p = new Pushpin();
                    
                    p.Location = new Location(lat[i], longi[i]);
                    
                    map1.Children.Add(p);
                }
                     map1.Children.Add(line);
             }
