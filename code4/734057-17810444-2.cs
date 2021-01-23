    public class TextBoxCtrl : ICustomizedUI, TextBox
    {
        #region ICustomizedUI
        public Boolean HasBorder { get; set; }
        public Boolean ShouldDrawBorder { get; set; }
        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            CustomizedUIHelper.AddCustomizedUI(this, e);
            base.OnPaint(e);
        }
    }
    /* other controls */
