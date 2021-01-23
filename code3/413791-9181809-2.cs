    //CollapsiblePanel.cs
    #region Properties
    ...
    /// <summary>
    /// Gets or sets the the background image used in the panel title
    /// </summary>
    [Category("Collapsible Panel")]
    [Description("Gets or sets the background image used in the panel title")]
    [DisplayName("Panel Title Background Image")]
    public Image PanelBackgroundImage
    {
        get { return titlePanel.BackgroundImage; }
        set { titlePanel.BackgroundImage = value; }
    }
    #endregion
    //frmTest.cs
    namespace StaffDotNet.CollapsiblePanel.Test
    {
        public partial class frmTest : Form
        {
            public frmTest()
            {
                InitializeComponent();
                this.collapsiblePanel1.PanelBackgroundImage = Image.FromFile(@"GreenBubbles.jpg");
            }
        }
    }
