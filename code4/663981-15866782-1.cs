      public partial class ClickToMove : Window
        {
            public List<MovableObject> Objects { get; set; } 
    
            public ClickToMove()
            {
                InitializeComponent();
    
                Objects = new List<MovableObject>
                    {
                        new MovableObject() {X = 100, Y = 100}
                    };
    
                DataContext = Objects;
            }
    
            private void ItemsControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                var position = e.GetPosition(this);
                Objects.First().MoveToPosition(position.X, position.Y);
            }
        }
