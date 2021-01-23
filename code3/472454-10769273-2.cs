    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }
        ...
    }
    <DataTemplate x:Key="MyTemplate1" DataType="{x:Type MyType1}">
        ...
    </DateTemplate>
    <DataTemplate x:Key="MyTemplate2" DataType="{x:Type MyType2}">
        ...
    </DateTemplate>
    <local:MyTemplateSelector 
        x:Key="MyTemplateSelector" 
        Template1="{StaticResource MyTemplate1}"
        Template2="{StaticResource MyTemplate2}"
    />
