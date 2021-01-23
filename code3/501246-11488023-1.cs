    public class Graph : PictureBox {
        ObservableCollection<Point> Curves;
        //And some code to take care of drawing the curves
    
        public Graph() {
          Curves.CollectionChanged += Curves_CollectionChanged;
        }
    
        void Curves_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
          Redraw();
        }
    }
