    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            #region --- Declarations ---
            private Rect _location { get; set; }
            #endregion
            #region --- Constructors ---
            public MainWindow()
            {
                InitializeComponent();
            }
            #endregion
            #region --- Properties ---
            private Rect DesktopArea
            {
                get
                {
                    var c = System.Windows.Forms.Cursor.Position;
                    var s = System.Windows.Forms.Screen.FromPoint(c);
                    var a = s.WorkingArea;
                    return new Rect(a.Left, a.Top, a.Width, a.Height);
                }
            }
            #endregion
            #region --- Dependency Properties ---
            public static readonly DependencyProperty InternalWindowStateProperty = DependencyProperty.Register("InternalWindowState", typeof(WindowState), typeof(MainWindow), new PropertyMetadata(WindowState.Normal, new PropertyChangedCallback(OnInternalWindowStateChanged)));
            public WindowState InternalWindowState
            {
                get { return (WindowState)GetValue(InternalWindowStateProperty); }
                set { SetValue(InternalWindowStateProperty, value); }
            }
            private static void OnInternalWindowStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MainWindow instance = (MainWindow)d;
                instance.SetInternalWindowState((WindowState)e.NewValue);
            }
            #endregion
            #region --- Private Methods ---
            private void StoreLocation()
            {
                _location = new Rect(this.Left, this.Top, this.Width, this.Height);
            }
            private void RestoreLocation()
            {
                this.Width = _location.Width;
                this.Height = _location.Height;
                this.Top = _location.Top >= 0 ? _location.Top : 0;
                this.Left = _location.Left;
            }
            private void SetMaximizedState()
            {
                this.Width = DesktopArea.Width;
                this.Height = DesktopArea.Height;
                this.Top = DesktopArea.Top;
                this.Left = DesktopArea.Left;
            }
            private void SetInternalWindowState(WindowState state)
            {
                InternalWindowState = state;
                switch (InternalWindowState)
                {
                    case WindowState.Normal:
                        this.WindowState = WindowState.Normal;
                        RestoreLocation();
                        break;
                    case WindowState.Maximized:
                        this.WindowState = WindowState.Normal;
                        SetMaximizedState();
                        break;
                    case WindowState.Minimized:
                        this.WindowState = WindowState.Minimized;
                        break;
                }
            }
            #endregion
            #region --- Sizing Routines --- 
            private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
            {
                Thumb thumb = (Thumb)sender;
                int tag = Convert.ToInt32(thumb.Tag);
                if (thumb.Cursor == Cursors.SizeWE) HandleSizeWE(tag, e);
                if (thumb.Cursor == Cursors.SizeNS) HandleSizeNS(tag, e);
                if (thumb.Cursor == Cursors.SizeNESW) HandleSizeNESW(tag, e);
                if (thumb.Cursor == Cursors.SizeNWSE) HandleSizeNWSE(tag, e);
            }
            private void HandleSizeNWSE(int tag, DragDeltaEventArgs e)
            {
                if (tag == 0)
                {
                    this.Top += e.VerticalChange;
                    this.Height -= e.VerticalChange;
                    this.Left += e.HorizontalChange;
                    this.Width -= e.HorizontalChange;
                }
                else
                {
                    this.Width += e.HorizontalChange;
                    this.Height += e.VerticalChange;
                }
            }
            private void HandleSizeNESW(int tag, DragDeltaEventArgs e)
            {
                if (tag == 0)
                {
                    this.Top += e.VerticalChange;
                    this.Height -= e.VerticalChange;
                    this.Width += e.HorizontalChange;
                }
                else
                {
                    this.Left += e.HorizontalChange;
                    this.Width -= e.HorizontalChange;
                    this.Height += e.VerticalChange;
                }
            }
            private void HandleSizeNS(int tag, DragDeltaEventArgs e)
            {
                if (tag == 0)
                {
                    this.Top += e.VerticalChange;
                    this.Height -= e.VerticalChange;
                }
                else
                    this.Height += e.VerticalChange;
            }
            private void HandleSizeWE(int tag, DragDeltaEventArgs e)
            {
                if (tag == 0)
                {
                    this.Left += e.HorizontalChange;
                    this.Width -= e.HorizontalChange;
                }
                else
                    this.Width += e.HorizontalChange;
            }
            #endregion
            #region --- Event Handlers ---
            private void OnDragMoveWindow(Object sender, MouseButtonEventArgs e)
            {
                if (this.InternalWindowState == WindowState.Maximized)
                {
                    var c = System.Windows.Forms.Cursor.Position;
                    this.InternalWindowState = WindowState.Normal;
                    this.Height = _location.Height;
                    this.Width = _location.Width;
                    this.Top = c.Y - (titleBar.ActualHeight / 2);
                    this.Left = c.X - (_location.Width / 2);
                }
                this.DragMove();
            }
            private void OnMaximizeWindow(Object sender, MouseButtonEventArgs e)
            {
                if (this.InternalWindowState == WindowState.Maximized)
                    this.InternalWindowState = WindowState.Normal;
                else
                    this.InternalWindowState = WindowState.Maximized;
            }
            private void OnMinimizeWindow(Object sender, MouseButtonEventArgs e)
            {
                this.InternalWindowState = WindowState.Minimized;
            }
            private void OnCloseWindow(Object sender, MouseButtonEventArgs e)
            {
                Application.Current.Shutdown();
            }
            private void Window_StateChanged(object sender, EventArgs e)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.InternalWindowState = WindowState.Maximized;
                }
            }
            private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (this.InternalWindowState != WindowState.Maximized)
                    StoreLocation();
            }
            #endregion
        }
    }
