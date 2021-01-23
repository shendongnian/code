    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Reactive.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                TreeStuff = new ObservableCollection<TreeThing>()
                    {
                        new TreeThing() { Description="file 1",  Path = @"c:\temp\test.txt" },
                        new TreeThing() { Description="file 2", Path = @"c:\temp\test2.txt" },
                        new TreeThing() { Description="file 3", Path = @"c:\temp\test3.txt" },
                    };
    
                var dragStart = 
                    from mouseDown in 
                        Observable.FromEventPattern<MouseButtonEventHandler, MouseEventArgs>(
                            h => tree.PreviewMouseDown += h, 
                            h => tree.PreviewMouseDown -= h)
                    let startPosition = mouseDown.EventArgs.GetPosition(null)
                    from mouseMove in 
                        Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
                            h => tree.MouseMove += h, 
                            h => tree.MouseMove -= h)
                    let mousePosition = mouseMove.EventArgs.GetPosition(null)
                    let dragDiff = startPosition - mousePosition
                    where mouseMove.EventArgs.LeftButton == MouseButtonState.Pressed && 
                        (Math.Abs(dragDiff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                        Math.Abs(dragDiff.Y) > SystemParameters.MinimumVerticalDragDistance)
                    select mouseMove;
    
                dragStart.ObserveOnDispatcher().Subscribe(start =>
                    {
                        var nodeSource = this.FindAncestor<TreeViewItem>(
                            (DependencyObject)start.EventArgs.OriginalSource);
                        var source = start.Sender as TreeView;
                        if (nodeSource == null || source == null)
                        {
                            return;
                        }
                        var data = (TreeThing)source
                            .ItemContainerGenerator
                            .ItemFromContainer(nodeSource);
                        DragDrop.DoDragDrop(nodeSource, new DataObject("treeThing", data), DragDropEffects.All);
                    });
    
                this.tb.AddHandler(UIElement.DragOverEvent, new DragEventHandler((sender, e) =>
                    {
                        e.Effects = !e.Data.GetDataPresent("treeThing") ? 
                            DragDropEffects.None : 
                            DragDropEffects.Copy;                    
                    }), true);
    
                this.tb.AddHandler(UIElement.DropEvent, new DragEventHandler((sender, e) =>
                {
                    if (e.Data.GetDataPresent("treeThing"))
                    {
                        var item = e.Data.GetData("treeThing") as TreeThing;
                        if (item != null)
                        {
                            tb.Text = item.Path;
                           // TODO: Actually open up the file here
                        }
                    }
                }), true);
                this.DataContext = this;
            }
    
    
            private T FindAncestor<T>(DependencyObject current)
                where T:DependencyObject
            {
                do
                {
                    if (current is T)
                    {
                        return (T)current;
                    }
                    current = VisualTreeHelper.GetParent(current);
                }
                while (current != null);
                return null;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<TreeThing> TreeStuff { get; set; }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class TreeThing
        {
            public string Description { get; set; }
            public string Path { get; set; }
        }
    }
