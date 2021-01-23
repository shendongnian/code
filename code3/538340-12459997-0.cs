    class MyClass : IDisposable
    { 
        internal Grid _grid = new Grid(); 
        internal Image _image = new Image() {Width = Double.NaN, Height = Double.NaN HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Stretch = Stretch.Fill}; 
        //... a lot of variables, data, images and methods... 
        public void Dispose()
        {
            // your custom disposing 
            _image = null; //or something like that
        }
    }
