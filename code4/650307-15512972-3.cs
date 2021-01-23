    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    namespace WpfApplication1
    {
        public class OpenCloseWindowBehavior : Behavior<UserControl>
        {
            private Window _windowInstance;
            public Type WindowType { get { return (Type)GetValue(WindowTypeProperty); } set { SetValue(WindowTypeProperty, value); } }
            public static readonly DependencyProperty WindowTypeProperty = DependencyProperty.Register("WindowType", typeof(Type), typeof(OpenCloseWindowBehavior), new PropertyMetadata(null));
            public bool Open { get { return (bool)GetValue(OpenProperty); } set { SetValue(OpenProperty, value); } }
            public static readonly DependencyProperty OpenProperty = DependencyProperty.Register("Open", typeof(bool), typeof(OpenCloseWindowBehavior), new PropertyMetadata(false, OnOpenChanged));
            /// <summary>
            /// Opens or closes a window of type 'WindowType'.
            /// </summary>
            private static void OnOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var me = (OpenCloseWindowBehavior)d;
                if ((bool)e.NewValue)
                {
                    object instance = Activator.CreateInstance(me.WindowType);
                    if (instance is Window)
                    {
                        Window window = (Window)instance;
                        window.Closing += (s, ev) => 
                        {
                            if (me.Open) // window closed directly by user
                            {
                                me._windowInstance = null; // prevents repeated Close call
                                me.Open = false; // set to false, so next time Open is set to true, OnOpenChanged is triggered again
                            }
                        }; 
                        window.Show();
                        me._windowInstance = window;
                    }
                    else
                    {
                        // could check this already in PropertyChangedCallback of WindowType - but doesn't matter until someone actually tries to open it.
                        throw new ArgumentException(string.Format("Type '{0}' does not derive from System.Windows.Window.", me.WindowType));
                    }
                }
                else 
                {
                    if (me._windowInstance != null)
                        me._windowInstance.Close(); // closed by viewmodel
                }
            }
        }
    }
