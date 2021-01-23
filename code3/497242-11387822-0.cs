    public class ShellViewModel : Screen
    {
       public ChildViewModel Child { get; set; }
       public void SomeAction()
       {
           Child = new ChildViewModel(); //Or inject using factory, IoC, etc.
       }
    }
    public class ShellView : Window
    {
    }
    <Window x:Class="WpfApplication1.ShellView"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
            xmlns:cal="http://www.caliburnproject.org">
        <Grid>
            <ContentControl cal:View.Model="{Binding Child}" />
        </Grid>
    </Window>
