    public partial class CustomTextBox : MaskedTextBox
    {
        public CustomTextBox()
        {
            InitializeComponent();
            this.BeepOnError = true;
            this.AsciiOnly = true;
            this.MaskInputRejected += new MaskInputRejectedEventHandler(CustomTextBox_MaskInputRejected);
        }
        // mark this event as virtual
       public virtual void CustomTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Character Position", e.Position);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Reason Rejected", e.RejectionHint);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "Input Mask Invalid...");
        }
