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
                    new Derp("Root", "Rootval") 
                    { 
                        Children = new List<IHerp>() 
                        { 
                            new Herp("Herp Child")
                            { 
                                Children =  new List<IHerp>() {new Derp("Herp Grandchild","GrandChild")}
                            },
                            new Herp("Herp Child2")
                            { 
                                Children =  new List<IHerp>() {new Derp("Herp Grandchild","GrandChild")}
                            },
                            new Herp("Derp Child")
                            { 
                                Children =  new List<IHerp>() {new Derp("Derp Grandchild","GrandChild")}
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
    }
