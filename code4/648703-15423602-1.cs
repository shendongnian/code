    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace NodesEditor
    {
        public partial class MainWindow : Window
        {
            public List<Node> Nodes { get; set; }
            public List<Connector> Connectors { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
    
                Nodes = NodesDataSource.GetRandomNodes().ToList();
                Connectors = NodesDataSource.GetRandomConnectors(Nodes).ToList();
    
                DataContext = this;
            }
    
            private void Thumb_Drag(object sender, DragDeltaEventArgs e)
            {
                var thumb = sender as Thumb;
                if (thumb == null)
                    return;
    
                var data = thumb.DataContext as Node;
                if (data == null)
                    return;
    
                data.X += e.HorizontalChange;
                data.Y += e.VerticalChange;
            }
        }
    }
