        public static DependencyProperty HealthDependency = DependencyProperty.Register("Health",
                                                                                        typeof(Double),
                                                                                        typeof(MyCharacter),
                                                                                        new PropertyMetadata(100.0, HealthDependencyChanged));
        private static void HealthDependencyChanged(DependencyObject source,
                DependencyPropertyChangedEventArgs e)
        {
        }
        public double Health
        {
            get
            {
                return (double)GetValue(HealthDependency);
            }
            set
            {
                SetValue(HealthDependency, value);
            }
        }
        public void DrinkHealthPotion(double healthRestored)
        {
            Health += healthRestored;
        }
           
    }
    public class MyCharacterAttributes : DependencyObject
    {
        public static DependencyProperty HealthDependency = DependencyProperty.Register("HealthValue",
                                                                                        typeof(Double),
                                                                                        typeof(MyCharacterAttributes),
                                                                                        new PropertyMetadata(100.0, HealthAttributeDependencyChanged));
        public double HealthValue
        {
            get
            {
                return (Double)GetValue(HealthDependency);
            }
            set
            {
                SetValue(HealthDependency, value);
            }
        }
        public List<BindingExpressionBase> Bindings { get; set; }
        public MyCharacterAttributes()
        {
            Bindings = new List<BindingExpressionBase>(); 
        }
        private static void HealthAttributeDependencyChanged(DependencyObject source,
                DependencyPropertyChangedEventArgs e)
        {
        }
    }
