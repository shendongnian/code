    MyCharacter Character { get; set; }
    MyCharacterAttributes CharacterAttributes = new MyCharacterAttributes();
    public MainWindow()
    {
        InitializeComponent();
        Character = new MyCharacter();
        CharacterAttributes = new MyCharacterAttributes();
        // Set up the data binding to point at Character (Source) and 
        // Property Health (via the constructor argument for Binding)
        var characterHealthBinding = new Binding("Health");
 
        characterHealthBinding.Source = Character;
        characterHealthBinding.NotifyOnSourceUpdated = true;
        characterHealthBinding.NotifyOnTargetUpdated = true;
        characterHealthBinding.Mode = BindingMode.TwoWay;
        characterHealthBinding.IsAsync = true;
        // Now we bind any changes to CharacterAttributes, HealthDependency 
        // to Character.Health via the characterHealthBinding Binding
        var bindingExpression = 
            BindingOperations.SetBinding(CharacterAttributes, 
                                         MyCharacterAttributes.HealthDependency,
                                         characterHealthBinding);
        // Store the binding so we can look it up if necessary in a 
        // List<BindingExpressionBase> in our CharacterAttributes class,
        // and so it "lives" as long as CharacterAttributes does, too
        CharacterAttributes.Bindings.Add(bindingExpression);
    }
    private void HitChracter_Button(object sender, RoutedEventArgs e)
    {
        CharacterAttributes.HealthValue -= 10.0;
    }
    private void DrinkHealth_Button(object sender, RoutedEventArgs e)
    {
        Character.DrinkHealthPotion(20.0);
    }
