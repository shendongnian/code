    public class LoggerButton : Button
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LoggerButton));
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Logger.InfoFormat("Button clicked: {0} ({1})", this.Text, this.Parent.Text);
        }
    }
