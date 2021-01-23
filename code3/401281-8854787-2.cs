    [ProvideProperty("CustomForeColor", typeof(Control))]
    [ProvideProperty("CustomBackColor", typeof(Control))]
    public class CustomColorExtenderProvider : Component, IExtenderProvider
    {
        public CustomColor GetCustomForeColor(Control control)
        {
            return CustomColor.Find(control.ForeColor);
        }
        public CustomColor GetCustomBackColor(Control control)
        {
            return CustomColor.Find(control.BackColor);
        }
        public void SetCustomBackColor(Control control, CustomColor value)
        {
            control.BackColor = value.Color;
        }
        public void SetCustomForeColor(Control control, CustomColor value)
        {
            control.ForeColor = value.Color;
        }
        public bool ShouldSerializeCustomForeColor(Control control)
        {
            return false;
        }
        public bool ShouldSerializeCustomBackColor(Control control)
        {
            return false;
        }
        #region IExtenderProvider Members
        public bool CanExtend(object extendee)
        {
            return (extendee is Control);
        }
        #endregion
    }
