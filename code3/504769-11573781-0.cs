    public class TheFormClass : Form
    {
        private static int _openCount = 0;
        protected override void OnLoad(EventArgs e)
        {
            _openCount++;
            base.OnLoad(e);
            this.Text = "Form" + _openCount;
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _openCount--;
            base.OnFormClosed(e);
        }
    }
