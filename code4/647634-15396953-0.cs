        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var pc = new PointCollection();
            pc.Add(new Point(10, 255));
            pc.Add(new Point(500, 255));
            pc.Add(new Point(500, 200));
            pc.Add(new Point(400, 150));
            pc.Add(new Point(200, 150));
            pc.Add(new Point(10, 200));
            return pc;//"10,255 500,255 500,200 400,150 200,150 10,200";
        }
