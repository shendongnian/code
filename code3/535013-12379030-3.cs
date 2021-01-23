    <Window x:Class="WpfApplication15.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <Style TargetType="{x:Type ContextMenu}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ContextMenu}">
                            <Border x:Name="border" Background="{TemplateBinding Background}" BorderBrush="{TemplateBinding BorderBrush}"
    BorderThickness="{TemplateBinding BorderThickness}">
                                <ScrollViewer x:Name="scrollviewer"
    Style="{DynamicResource {ComponentResourceKey ResourceId=MenuScrollViewer, TypeInTargetAssembly={x:Type FrameworkElement}}}"
    CanContentScroll="True" >
                                    <ItemsPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" Margin="{TemplateBinding Padding}"
    KeyboardNavigation.DirectionalNavigation="Cycle"/>
                                </ScrollViewer>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Window.Resources>
        <Grid>
            <Button x:Name="mybutton">
                <Button.ContextMenu>
                    <ContextMenu>
                        <MenuItem Header="Test1"/>
                    </ContextMenu>
    			</Button.ContextMenu>
                Test Button
            </Button>		
    	</Grid>
    </Window>
----------
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
    using System.Windows.Controls.Primitives;
    
    namespace WpfApplication15
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            return (T)child;
                        }
    
                        T childItem = FindVisualChild<T>(child);
                        if (childItem != null) return childItem;
                    }
                }
                return null;
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                ContextMenu contextmenu = mybutton.ContextMenu;
    
                // Add 100 more items
    
                for (int i = 2; i <= 100; i++)
                {
                    MenuItem mi = new MenuItem();
                    mi.Header = "Item" + i.ToString();
    
                    contextmenu.Items.Add(mi);
                }
    
                contextmenu.SizeChanged += new SizeChangedEventHandler(contextmenu_SizeChanged);
                contextmenu.Loaded += new RoutedEventHandler(contextmenu_Loaded);
    
                mybutton.ContextMenuOpening += new ContextMenuEventHandler(mybutton_ContextMenuOpening);
            }
    
            void contextmenu_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                ContextMenu contextmenu = mybutton.ContextMenu;
    
                ScrollViewer sv = FindVisualChild<ScrollViewer>(contextmenu);
                if (sv != null)
                {
                    sv.ScrollToEnd();
                }
            }
    
            void contextmenu_Loaded(object sender, RoutedEventArgs e)
            {
                ContextMenu contextmenu = mybutton.ContextMenu;
    
                ScrollViewer sv = FindVisualChild<ScrollViewer>(contextmenu);
                if (sv != null)
                {
                    sv.ScrollToEnd();
                }
            }
    
            void mybutton_ContextMenuOpening(object sender, ContextMenuEventArgs e)
            {
                ContextMenu contextmenu = mybutton.ContextMenu;
                ScrollViewer sv = FindVisualChild<ScrollViewer>(contextmenu);
                if (sv != null)
                {
                    sv.ScrollToEnd();
                }
            }
        }
    }
