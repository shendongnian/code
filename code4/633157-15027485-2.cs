    public class FormA : Form {
      private FormB formB;
      public FormA() {
      }
      private void FormBShow_Clicked(object sender, EventArgs e) {
        FormB_Show();
      }
      private void FormB_Show() {
        FormB_DialogResult = DialogResult.None;
        formB = new FormB();
        formB.Closed += new EventHandler(FormB_Closed);
        formB.CustomMessage = "This is FormB. When it closes, " +
          "it will call FormA's FormB_Closed event handler, " +
          "which will set the FormB_DialogResult property.";
        formB.Show();
      }
      void FormB_Closed(object sender, EventArgs e) {
        FormB_DialogResult = formB.DialogResult;
        if (FormB_DialogResult == DialogResult.OK) {
          if (formB.FormC_DialogResult == DialogResult.OK) {
            // Update Form C information
          }
          // Update Form B information
        }
      }
      private DialogResult FormB_DialogResult { get; set; }
    }
