    class A : BaseObjectImplementingINotifyPropertyChanged {
      private string m_name;
      public string Name {
        get { return m_name; }
        set {
          if(m_name != value) {
            m_name = value;
            RaisePropertyChanged("Name");
          }
        }
      }
    }
    class B : BaseObjectImplementingINotifyPropertyChanged {
      private A m_a;
      public A A {
        get { return m_a; }
        set {
          if(m_a != value) {
            if(m_a != null) { m_a.PropertyChanged -= OnAPropertyChanged;
            m_a = value;
            if(m_a != null) { m_a.PropertyChanged += OnAPropertyChanged;
            RaisePropertyChanged("A");
          }
        }
      }
      private void OnAPropertyChanged(object sender, PropertyChangedEventArgs e) {
        RaisePropertyChanged("A." + e.PropertyName);
      }
    }
    B b = new B();
    b.PropertyChanged += (s, e) => { Console.WriteLine(e.PropertyName); };
    b.A.Name = "Blah"; // Will print "A.Name"
