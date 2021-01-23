    using System.Windows.Interop;
    using winforms = System.Windows.Forms;
    
    namespace CustomWindowDemo
    {
        /// <summary>
        /// Interaction logic for DemoCustomWindow.xaml
        /// </summary>
        public partial class DemoCustomWindow : Window
        {
            bool Maximized = false;
            int NormalWidth = 0;
            int NormalHeight = 0;
            int NormalX = 0;
            int NormalY = 0;
    
            public DemoCustomWindow()
            {
                InitializeComponent();
            }
    
            #region Header & Resize
            void Header_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
            {
                if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                    this.DragMove();
            }
    
            void ThumbBottomRightCorner_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Width + e.HorizontalChange > 10)
                    this.Width += e.HorizontalChange;
                if (this.Height + e.VerticalChange > 10)
                    this.Height += e.VerticalChange;
            }
            void ThumbTopRightCorner_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Width + e.HorizontalChange > 10)
                    this.Width += e.HorizontalChange;
                if (this.Top + e.VerticalChange > 10)
                {
                    this.Top += e.VerticalChange;
                    this.Height -= e.VerticalChange;
                }
            }
            void ThumbTopLeftCorner_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Left + e.HorizontalChange > 10)
                {
                    this.Left += e.HorizontalChange;
                    this.Width -= e.HorizontalChange;
                }
                if (this.Top + e.VerticalChange > 10)
                {
                    this.Top += e.VerticalChange;
                    this.Height -= e.VerticalChange;
                }
            }
            void ThumbBottomLeftCorner_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Left + e.HorizontalChange > 10)
                {
                    this.Left += e.HorizontalChange;
                    this.Width -= e.HorizontalChange;
                }
                if (this.Height + e.VerticalChange > 10)
                    this.Height += e.VerticalChange;
            }
            void ThumbRight_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Width + e.HorizontalChange > 10)
                    this.Width += e.HorizontalChange;
            }
            void ThumbLeft_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Left + e.HorizontalChange > 10)
                {
                    this.Left += e.HorizontalChange;
                    this.Width -= e.HorizontalChange;
                }
            }
            void ThumbBottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Height + e.VerticalChange > 10)
                    this.Height += e.VerticalChange;
            }
            void ThumbTop_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                if (this.Top + e.VerticalChange > 10)
                {
                    this.Top += e.VerticalChange;
                    this.Height -= e.VerticalChange;
                }
            }
    
            void btn_Minimize_Click(object sender, RoutedEventArgs e)
            {
                WindowState = WindowState.Minimized;
            }
            void btn_Maximize_Click(object sender, RoutedEventArgs e)
            {
                if (Maximized == true)
                {
                    this.Width = NormalWidth;
                    this.Height = NormalHeight;
                    this.Left = NormalX;
                    this.Top = NormalY;
                    Maximized = false;
                    Thumbs();
                }
                else
                {
                    NormalX = (int)this.Left;
                    NormalY = (int)this.Top;
                    NormalHeight = (int)this.Height;
                    NormalWidth = (int)this.Width;
                    this.Left = winforms.Screen.FromHandle(new WindowInteropHelper(this).Handle).WorkingArea.Left;
                    this.Top = winforms.Screen.FromHandle(new WindowInteropHelper(this).Handle).WorkingArea.Top;
                    this.Width = winforms.Screen.FromHandle(new WindowInteropHelper(this).Handle).WorkingArea.Width;
                    this.Height = winforms.Screen.FromHandle(new WindowInteropHelper(this).Handle).WorkingArea.Height;
                    Maximized = true;
                    Thumbs();
                }
            }
            void btn_Close_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }
            void Thumbs()
            {
                if (Maximized == true)
                {
                    ThumbBottom.Visibility = Visibility.Collapsed;
                    ThumbLeft.Visibility = Visibility.Collapsed;
                    ThumbTop.Visibility = Visibility.Collapsed;
                    ThumbRight.Visibility = Visibility.Collapsed;
                    ThumbTopLeftCorner.Visibility = Visibility.Collapsed;
                    ThumbTopRightCorner.Visibility = Visibility.Collapsed;
                    ThumbBottomLeftCorner.Visibility = Visibility.Collapsed;
                    ThumbBottomRightCorner.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ThumbBottom.Visibility = Visibility.Visible;
                    ThumbLeft.Visibility = Visibility.Visible;
                    ThumbTop.Visibility = Visibility.Visible;
                    ThumbRight.Visibility = Visibility.Visible;
                    ThumbTopLeftCorner.Visibility = Visibility.Visible;
                    ThumbTopRightCorner.Visibility = Visibility.Visible;
                    ThumbBottomLeftCorner.Visibility = Visibility.Visible;
                    ThumbBottomRightCorner.Visibility = Visibility.Visible;
                }
            }
            #endregion
        }
    }
