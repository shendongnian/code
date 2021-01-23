    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using Telerik.Windows.Controls;
    
    namespace so.Tel.RadPaneCloseAll
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                CommandManager.RegisterClassCommandBinding(
                    typeof( RadPaneGroup ),
                    new CommandBinding(
                            RadDockingCommands.CloseAllPanesButThisCommand,
                            RadDockingCommands.OnCloseAllPanesButThis,
                            RadDockingCommands.OnCloseAllPanesButThisCanExecute ) );
            }
        }
    
        public static class RadDockingCommands
        {
            private static RoutedUICommand closeAllPanesButThisCommand;
    
            public static RoutedUICommand CloseAllPanesButThisCommand
            {
                get
                {
                    if( closeAllPanesButThisCommand == null )
                    {
                        closeAllPanesButThisCommand = new RoutedUICommand( "Close all panes but this",
                                                                           "CloseAllPanesButThisCommand",
                                                                           typeof( RadDockingCommands ) );
                    }
                    return closeAllPanesButThisCommand;
                }
            }
    
            public static void OnCloseAllPanesButThis( object sender, ExecutedRoutedEventArgs e )
            {
                var pane = e.Parameter as RadPane;
                if( pane != null )
                {
                    var paneGroup = pane.PaneGroup;
                    if( paneGroup != null )
                    {
                        var panesToClose = paneGroup.EnumeratePanes().Where( x => !x.IsHidden && x.IsPinned );
                        foreach( var paneToClose in panesToClose )
                        {
                            if( paneToClose != pane )
                            {
                                paneToClose.IsHidden = true;
                            }
                        }
                    }
                }
            }
    
            public static void OnCloseAllPanesButThisCanExecute( object sender, CanExecuteRoutedEventArgs e )
            {
                e.CanExecute = false;
                var paneGroup = sender as RadPaneGroup;
                if( paneGroup != null )
                {
                    int childrenCount = paneGroup.EnumeratePanes().Count( x => !x.IsHidden && x.IsPinned );
    
                    if( childrenCount > 1 )
                    {
                        e.CanExecute = true;
                    }
                    else
                    {
                        e.CanExecute = false;
                    }
                }
            }
        }
    }
