    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    namespace App75
    {
        public static class CountHelper
        {
            public static readonly DependencyProperty TitleProperty =
                DependencyProperty.RegisterAttached("Title", typeof(string), typeof(CountHelper), new PropertyMetadata(default(string)));
            public static void SetTitle(UIElement element, string value)
            {
                element.SetValue(TitleProperty, value);
            }
            public static string GetTitle(UIElement element)
            {
                return (string)element.GetValue(TitleProperty);
            }
        }
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
        }
    }
    <Page
        x:Class="App75.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:App75"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
        <Grid
            Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
            <TextBlock
                x:Name="tb"
                local:CountHelper.Title="Hello"
                Text="{Binding Path=(local:CountHelper.Title), ElementName=tb}" />
        </Grid>
    </Page>
