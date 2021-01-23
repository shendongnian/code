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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using GraphSharp;
    using QuickGraph;
    using GraphSharp.Controls;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public IBidirectionalGraph<object, IEdge<object>> Graph { get; set; }
            public MainWindow()
            {
                var g = new BidirectionalGraph<object, IEdge<object>>();
                IList<Object> vertices = new List<Object>();
                for (int i = 0; i < 6; i++)
                {
                    vertices.Add(i.ToString() );
                }
                for (int i = 0; i < 5; i++)
                {
                    Color edgeColor = (i % 2 == 0) ? Colors.Black : Colors.Red;
                    Console.WriteLine(edgeColor);
                    g.AddVerticesAndEdge(new MyEdge(vertices[i], vertices[i+1]) { 
                        Id = i.ToString(),
                        EdgeColor = edgeColor
                    });
                }
                Graph = g;
                Console.WriteLine(Graph.VertexCount);
                Console.WriteLine(Graph.EdgeCount);
                InitializeComponent();
            }
        }
        public class MyEdge : TypedEdge<Object>
        {
            public String Id { get; set; }
            public Color EdgeColor { get; set; }
            public MyEdge(Object source, Object target) : base(source, target, EdgeTypes.General) { }
        }
        public class EdgeColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return new SolidColorBrush((Color) value);
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
