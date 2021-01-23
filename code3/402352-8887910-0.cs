    public class SpecialLayer : MapLayer
    {
        public static readonly DependencyProperty ItemsSource ... 
        OnPropertyChanged(...) 
        {
            var layer = sender as SpecialLayer;
            foreach(Object in Routes){
                layer.Add(new Pushpin(...));
            }
        }
    }
