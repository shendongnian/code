    public class FormB : Form {
      private FormC formC;
      public FormB() {
        this.DialogResult = DialogResult.None;
      }
      private void Cancel_Clicked(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        Close();
      }
      private void OK_Clicked(object sender, EventArgs e) {
        this.DialogResult = DialogResult.OK;
        Close();
      }
      public string CustomMessage { get; set; }
      public void FormC_Show() {
        FormC_DialogResult = DialogResult.None;
        formC = new FormC();
        formC.Closed += new EventHandler(FormC_Closed);
        formC.CustomMessage = "This is FormC. When it closes, " +
          "it will call FormB's FormC_Closed event handler, " +
          "which will set the FormC_DialogResult property.";
        formC.Show();
      }
      private void FormC_Closed(object sender, EventArgs e) {
        FormC_DialogResult = formC.DialogResult;
        if (FormC_DialogResult == DialogResult.OK) {
          this.DialogResult = DialogResult.OK;
          Close();
        }
      }
      public DialogResult FormC_DialogResult { get; set; }
    }
