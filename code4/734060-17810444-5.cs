    public class TextBoxCtrl : ICtrl, TextBox
    {
        #region ICtrl
        public Boolean HasBorder { get; set; }
        public Boolean ShouldDrawBorder { get; set; }
        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            CtrlHelper.HandleUI(this, e);
            base.OnPaint(e);
        }
    }
    /* other controls */
