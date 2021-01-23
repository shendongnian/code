    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if(!m_inMouseMove)
            {
                m_inMouseMove = true;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    ++m_dragIndex;
                    System.Console.WriteLine("Dragged: " + m_dragIndex.ToString());
                    DragDrop.DoDragDrop(m_button, m_dragIndex, DragDropEffects.All);
                    e.Handled = true;
                }
                m_inMouseMove = false;
            }
        }
    
        private void Drop(object sender, DragEventArgs e)
        {
            System.Console.WriteLine("Dropped: " + e.Data.GetData(typeof(Int32)).ToString());
        }
    
        private int m_dragIndex;
        bool m_inMouseMove;
    }
