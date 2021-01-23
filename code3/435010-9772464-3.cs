        public class ListViewItemDoubleClickCommandBehaviour : CommandBehaviorBase<ListViewItem>
        {
            public ListViewItemDoubleClickCommandBehaviour(ListViewItem controlToWhomWeBind)
            : base(controlToWhomWeBind)
            {
                controlToWhomWeBind.MouseDoubleClick += OnDoubleClick;
            }
            private void OnDoubleClick(object sender, System.Windows.RoutedEventArgs e)
            {
            
                ExecuteCommand();
          
            }
        }
