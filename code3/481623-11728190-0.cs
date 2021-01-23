    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication5
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += new RoutedEventHandler(MainWindow_Loaded);
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                // Create menu item.
                MenuItem exitMenuItem = new MenuItem();
                exitMenuItem.Header = "E_xit";
                exitMenuItem.Click +=new RoutedEventHandler(exitMenuItem_Click);
    
                // Create contextual menu.
                ContextMenu contextMenu = new ContextMenu();
                contextMenu.Items.Add(exitMenuItem);
    
                // Attach context-menu to something.
                myButton.ContextMenu = contextMenu; // Assuming there's a button on window named "myButton".
            }
    
            public void exitMenuItem_Click(object sender, RoutedEventArgs e)
            {
                // This gets executed when user right-clicks button, and presses x down on their keyboard.
                // TODO: Exit logic.
            }
        }
    }
    <Window x:Class="WpfApplication5.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow">
        <Grid>
            <Button x:Name="myButton" />
        </Grid>
    </Window>
