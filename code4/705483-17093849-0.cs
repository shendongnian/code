    public class SurfaceToolboxItem : ToolboxItem
    {
        private delegate void SetTextHandler(Control c, string text);
        public string ReportFieldName { get; set; }
        protected override IComponent[] CreateComponentsCore(IDesignerHost host)
        {
            var ctrl = (Label)host.CreateComponent(typeof(Label));
            var root = (Control) host.RootComponent;
            root.BeginInvoke(new SetTextHandler(SetText),
                             new object[] {ctrl, ReportFieldName});
            return new IComponent[]{ ctrl };
        }
        private void SetText(Control ctrl, string text)
        {
            ctrl.Text = text;
        }
    }
