    public class MyViewModel : ... (view model base)
    {
        public MyThingCollection Items{get; private set;}
    }
    <ItemsControl
         ItemsSource="{Binding Items}"
         ItemsTemplateSelector="{StaticResource MyTemplateSelector}"
         ...
