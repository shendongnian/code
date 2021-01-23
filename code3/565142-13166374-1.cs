      public partial class MyUserControl : UserControl
      {
        public MyUserControl()
        {
          InitializeComponent();
        }
    
        public string InputValue
        {
          get { return (string)GetValue(InputValueProperty); }
          set { SetValue(InputValueProperty, value); }
        }
        public static readonly DependencyProperty InputValueProperty =
            DependencyProperty.Register("InputValueProperty", typeof(string),
            typeof(MyUserControl));
      }
    <UserControl x:Class="WpfApplication4.MyUserControl"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:local="clr-namespace:WpfApplication4" Height="30" Width="300">
        <Grid>
           <TextBox Text="{Binding Path=InputValue, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type local:MyUserControl}}}" />
        </Grid>
    </UserControl>
