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
    using System.Collections;
    namespace stackoverflowTreeview
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Data = new List<IHerp>()
                {
                    new Derp("Derp Root", "Derp Root Value")  
                    { 
                        Children = new List<IHerp>() 
                        { 
                            new Herp("Herp Child")
                            { 
                                Children =  new List<IHerp>() {new Derp("Derp Grandchild","Derp GrandChild Value")}
                            },
                            new Derp("Derp Child2", "Derp Child2 Value")
                            { 
                                Children =  new List<IHerp>() {new Derp("Derp Grandchild","Derp GrandChild Value")}
                            },
                            new Herp("Herp Child")
                            { 
                                Children =  new List<IHerp>() {new Derp("Derp Grandchild","Derp GrandChild Value")}
                            }
                        }
                    }
                };
            
            }
            public static DependencyProperty dData = DependencyProperty.Register("Data", typeof(List<IHerp>), typeof(MainWindow));
    
            public List<IHerp> Data
            {
                get { return (List<IHerp>)GetValue(dData); }
                set { SetValue(dData, value); }
            }
        }
        public abstract class IHerp : DependencyObject
        {
            public static DependencyProperty dChildren = DependencyProperty.Register("Children", typeof(List<IHerp>), typeof(IHerp));
            public List<IHerp> Children { get { return (List<IHerp>)GetValue(dChildren); } set { SetValue(dChildren, value); } }
            public static DependencyProperty dName = DependencyProperty.Register("Name", typeof(string), typeof(IHerp));
            public string Name { get{return (string)GetValue(dName);} set{SetValue(dName,value);} }
            public IHerp()
            {
                Children = Children == null ? new List<IHerp>() : Children;
                Name = Name == null ? "" : Name;
            }
        }
    
        public class Herp : IHerp
        {
            public Herp(string name)
            {
                Name = name;
            }
        }
    
        public class Derp : IHerp
        {
            public string Value { get; set; }
            public Derp(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
        public class testConv : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    return value;
                }
                catch { return typeof(object); }
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
