    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    
    namespace DST_Common_Silverlight_Controls
    {
        /// <summary>
        /// Bug in ChildWindow sometimes leaves app disabled. 
        /// </summary>
        public class ChildWindowEx : ChildWindow
        {
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                Application.Current.RootVisual.SetValue(Control.IsEnabledProperty, true);
            }
        }
    }
