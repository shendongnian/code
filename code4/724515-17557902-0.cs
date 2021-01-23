    public class Tester {
      public Tester(string name, string surname) {
        Name = name;
        Surname = surname;
      }
    
      public string Name { get; set; }
      
      public string Surname { get; set; }
      
      public override string ToString() {
        return Name + " " + Surname;
      }
    }
    
    public class TheT : DependencyObject {
      public static readonly DependencyProperty TesterObjectProperty =
        DependencyProperty.Register("TesterObject", typeof(ObservableCollection<Tester>), typeof(TheT),
                                    new FrameworkPropertyMetadata());
      
      public ObservableCollection<Tester> TesterObject {
        get { return (ObservableCollection<Tester>)GetValue(TesterObjectProperty); }
        set { SetValue(TesterObjectProperty, value); }
      }
      
      public TheT(Collection<Tester> col) {
        TesterObject = new ObservableCollection<Tester>();
        foreach (Tester t in col) { TesterObject.Add(t); }
      }
    
      public void Add(Collection<Tester> col) {
        TesterObject.Clear();
        foreach (Tester t in col) { TesterObject.Add(t); }
      }
    }
    
    public Window1()
    {
      InitializeComponent();
      
      ObservableCollection<Tester> Tester1 = new ObservableCollection<Tester>();
      Tester1.Add(new Tester("Sunny", "Jenkins"));
      Tester1.Add(new Tester("Pieter", "Pan"));
    
      ObservableCollection<Tester> Tester2 = new ObservableCollection<Tester>();
      Tester2.Add(new Tester("Jack", "Sanders"));
      Tester2.Add(new Tester("Bill", "Trump"));
    
      var myDataV = new ObservableCollection<TheT>();
      myDataV.Add(new TheT(Tester1));
      myDataV.Add(new TheT(Tester2));
    
      IControl.ItemsSource = myDataV;
    }
