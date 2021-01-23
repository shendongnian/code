    public class ExampleViewModel : PropertyChangedBase
    {
        public ExampleViewModel ()
        {
            this.DoThisAndThatCommand = new ExampleCommand(this);
        }
    
        public CommandBase DoThisAndThatCommand { get; set; }
    }
    
    
    // and in XAML, you can use it like
    <Button x:Name="Ok"
                Command="{Binding DoThisAndThatCommand }" />
