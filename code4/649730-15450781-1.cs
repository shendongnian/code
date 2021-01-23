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
    
    namespace WpfApplication2
    {
        [Serializable()]
        public class Child
        {
            public string Property1 { get; set; }
        }
    
        [Serializable()]
        public class TestClass
        {
    
            public int Property1 { get; set; }
            public string Property2 { get; set; }
            public DateTime Property3 { get; set; }
            public Child Child { get; set; }
        }
    
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                TestClass testClass = new TestClass()
                {
                    Property1 = 1,
                    Property2 = "test",
                    Property3 = DateTime.Now,
                    Child = new Child()
                    {
                         Property1 = "test", 
                    }
                };
    
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                formatter.Serialize(memoryStream, testClass);
    
                memoryStream.Position = 0;
                TestClass deserialized = formatter.Deserialize(memoryStream) as TestClass;
            }
        }
    }
