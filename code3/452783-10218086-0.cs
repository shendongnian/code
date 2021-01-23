       public static readonly DependencyProperty PersonProperty =
                              DependencyProperty.Register("Person", typeof(Person),
                                                          typeof(ExampleHRControl));
    
       public Person Person
       {
          get { return (Person)GetValue(PersonProperty); }
          set { SetValue(PersonProperty, value); }
       }
