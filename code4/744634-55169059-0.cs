    public class ComboBoxFixMem : ComboBox
    {
        public ComboBoxFixMem()
        {
            this.DataContextChanged += ComboBox_DataContextChanged;
        }
        private void ComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext != null)
                return;
            FrameworkElement fe = this.GetTemplateChild("PART_Popup") as FrameworkElement;
            if (null != fe)
                fe.DataContext = null;
            PopupFixMem.ClearPopupDataContext(fe as Popup);
        }
    }
    public class ContextMenuFixMem : ContextMenu
    {
        protected override void OnClosed(RoutedEventArgs e)
        {
            base.OnClosed(e);
            FrameworkElement p = this.Parent as FrameworkElement;
            if (null != p)
                p.DataContext = null;
        }
    }
    public class PopupFixMem : Popup
    {
        public PopupFixMem()
        {
            this.DataContextChanged += Popup_DataContextChanged;
        }
        private void Popup_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext != null)
                return;
            ClearPopupDataContext(this);
        }
        public static void ClearPopupDataContext(Popup popup)
        {
            if (null == popup)
                return;
            try
            {
                var fiPopupRoot = typeof(Popup).GetField("_popupRoot", BindingFlags.NonPublic | BindingFlags.Instance);
                var popupRootWrapper = fiPopupRoot?.GetValue(popup);
                if (null == popupRootWrapper)
                    return;
                var valueFieldInfo = popupRootWrapper.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance);
                var popupRoot = valueFieldInfo?.GetValue(popupRootWrapper, new object[0]) as FrameworkElement;
                if (null != popupRoot)
                    popupRoot.DataContext = null;
            }
            catch (Exception) { }
        }
    }
