    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace test
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MyCommand(object sender, ExecutedRoutedEventArgs e)
            {
                MessageBox.Show("Test");
            }
        }
    }
    
    <Window x:Class="test.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
      <Window.CommandBindings>
        <CommandBinding Command="ApplicationCommands.Save" Executed="MyCommand" />
      </Window.CommandBindings>
    
      <Window.InputBindings>
        <KeyBinding Key="S" Modifiers="Control" Command="ApplicationCommands.Save"/>
      </Window.InputBindings>
    
      <Grid>
        <Menu IsMainMenu="True">
         <MenuItem Header="_File">
          <MenuItem Header="Save" Name="MainMenu_File_Save" Command="ApplicationCommands.Save" />
         </MenuItem>
       </Menu>
      </Grid>
    </Window>
