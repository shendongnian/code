    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                string value = "Document 1";
                
                if (Tmp.InputBox("New document", "New document name:", ref value, new Bitmap("Your Image Here") == DialogResult.OK)
                {
                    this.Text = value;
                }
            }
        }
        public static class Tmp  //Note new field called bitmap for passing your picture to the InputBox
        {
            public static DialogResult InputBox(string title, string promptText, ref string value, Bitmap image)
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();
                PictureBox picture = new PictureBox();
                
                form.Text = title;
                label.Text = promptText;
                textBox.Text = value;
                picture.Image = image;
                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;
                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);
                picture.SetBounds(14, 60, 128, 128);
                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                picture.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                form.ClientSize = new Size(396, 400); //Changed size to see the image
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height); //Changed position so you are not shrinking the available size after the controls are added
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel, picture});
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk; 
                form.CancelButton = buttonCancel;
                DialogResult dialogResult = form.ShowDialog();
                value = textBox.Text;
                return dialogResult;
            }
        }
    }
