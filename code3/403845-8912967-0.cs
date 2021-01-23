    public enum ControlLayoutEnum
    {
        SearchTab = 0,
        ViewTab = 1,
        ReportTab = 2
    }
    public class TabViewControl: System.Web.UI.UserControl
    {
        public ControlLayoutEnum ControlLayout { get; set; }
        protected override OnInit(object sender)
        {
            // Create controls required or Hide/Show PlaceHolder or Panel etc
            switch (this.ControlLayout)
            {
                case ControlLayoutEnum.SearchTab: // Create Search Layout
                    break;
        }
    }
