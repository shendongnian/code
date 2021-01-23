    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IBidirectionalGraph<object, IEdge<object>> _graphToVisualize;
    
        public IBidirectionalGraph<object, IEdge<object>> GraphToVisualize {
          get { return this._graphToVisualize; }
          set {
            if (!Equals(value, this._graphToVisualize)) {
              this._graphToVisualize = value;
              this.RaisePropChanged("GraphToVisualize");
            }
          }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void RaisePropChanged(string name) {
          var eh = this.PropertyChanged;
          if (eh != null) {
            eh(this, new PropertyChangedEventArgs(name));
          }
        }
        
        private void CreateGraphToVisualize()
        {
            var g = new BidirectionalGraph<object, IEdge<object>>();
    
            // add the vertices to the graph
            string[] vertices = new string[5];
            for (int i = 0; i < 5; i++)
            {
                vertices[i] = i.ToString();
                g.AddVertex(vertices[i]);
            }
    
            // add edges to the graph
            g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[2]));
            g.AddEdge(new Edge<object>(vertices[2], vertices[3]));
            g.AddEdge(new Edge<object>(vertices[3], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[4]));
    
            GraphToVisualize = g;
        }
    }
