    public partial class CustomTextBox : MaskedTextBox
    {
        public CustomTextBox()
        {
            InitializeComponent();
            this.BeepOnError = true;
            this.AsciiOnly = true;
            this.MaskInputRejected += new MaskInputRejectedEventHandler(CustomTextBox_MaskInputRejected);
        }
        /// <summary>
        /// Alas this event is not virtual in the base MS class like other events. Hence,
        /// we have to mark it as virtual now
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       public virtual void CustomTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Character Position", e.Position);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Reason Rejected", e.RejectionHint);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "Input Mask Invalid...");
        }
}
// Derive a class like this and override the event where you delegate the request to the base class
     public class MyMaskedBox : CustomTextBox
        {
            public override void CustomTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
            {
                base.CustomTextBox_MaskInputRejected(sender, e);
            }
        }
 
