     /// <summary>
    /// ALL THE APP POP UP HAVE TO INHERIT from ChildWindowEx
    /// prevents the greyish app bug
    /// </summary>
    public class ChildWindowEx : ChildWindow
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.RootVisual.SetValue(Control.IsEnabledProperty, true);
        }
    }
