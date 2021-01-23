    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        public class Animal : DependencyObject
        {
            public string Name
            {
                get { return (string)GetValue(NameProperty); }
                set { SetValue(NameProperty, value); }
            }
            public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Animal), new PropertyMetadata(null));
    
            public bool TastesGood
            {
                get { return (bool)GetValue(TastesGoodProperty); }
                set { SetValue(TastesGoodProperty, value); }
            }
            public static readonly DependencyProperty TastesGoodProperty = DependencyProperty.Register("TastesGood", typeof(bool), typeof(Animal), new PropertyMetadata(false));
    
            public Enclosure Enclosure
            {
                get { return (Enclosure)GetValue(EnclosureProperty); }
                set { SetValue(EnclosureProperty, value); }
            }
            public static readonly DependencyProperty EnclosureProperty = DependencyProperty.Register("Enclosure", typeof(Enclosure), typeof(Animal), new PropertyMetadata(null));
    
        }
    
        public class Enclosure : DependencyObject
        {
            public string Name
            {
                get { return (string)GetValue(NameProperty); }
                set { SetValue(NameProperty, value); }
            }
            public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(Enclosure), new PropertyMetadata(null));
    
            public string Location
            {
                get { return (string)GetValue(LocationProperty); }
                set { SetValue(LocationProperty, value); }
            }
            public static readonly DependencyProperty LocationProperty = DependencyProperty.Register("Location", typeof(string), typeof(Enclosure), new PropertyMetadata(null));
        }
    
        public partial class MainWindow : Window
        {
            public ObservableCollection<Animal> Animals
            {
                get { return (ObservableCollection<Animal>)GetValue(AnimalsProperty); }
                set { SetValue(AnimalsProperty, value); }
            }
            public static readonly DependencyProperty AnimalsProperty = DependencyProperty.Register("Animals", typeof(ObservableCollection<Animal>), typeof(MainWindow), new PropertyMetadata(null));
    
            public MainWindow()
            {
                InitializeComponent();
    
                Animals = new ObservableCollection<Animal>();
                Animals.Add(new Animal() { Name = "Cow", TastesGood = true, Enclosure = null });
                Animals.Add(new Animal()
                {
                    Name = "Chicken",
                    TastesGood = true,
                    Enclosure =
                        new Enclosure()
                        {
                            Name = "chicken coop",
                            Location = "outside"
                        }
                });
            }
        }
    }
