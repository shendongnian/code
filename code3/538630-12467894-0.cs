    namespace ContractManagement.Forms
        {
            public partial class BaseForm : Form
            {
                private Boolean DialogStyle;
                private Boolean NoControlButtons;
        
                public BaseForm()
                {
                    InitializeComponent();
                    TitleLabel.Visible = DialogStyle = true;
                    ControlBox = NoControlButtons = true;
                }
        
                public Boolean DialogForm
                {
                    get
                    {
                        return DialogStyle;
                    }
                    set
                    {
                        DialogStyle = TitleLabel.Visible = value;
                        DialogStyle = CommandPanel.Visible = value;
                    }
                }
        
                public Boolean ControlButtons
                {
                    get
                    {
                        return NoControlButtons;
                    }
                    set
                    {
                        NoControlButtons = ControlBox = value;
                    }
                }
        
                protected override void OnTextChanged(EventArgs e)
                {
                    base.OnTextChanged(e);
                    TitleLabel.Text = Text;
                }
            }
        }
