    public class FormC : Form {
      public FormC() {
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
    }
