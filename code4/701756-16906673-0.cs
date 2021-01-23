    public interface IInputter
    {
        event EventHandler<InputReceivedEventArgs> ReceivedInput;
    }
    public class InputReceivedEventArgs : EventArgs
    {
        public InputReceivedEventArgs(string text)
        {
            this.Text = text;
        }
        public string Text { get; private set; }
    }
    public partial class Form1 : Form, IInputter
    {
        public event EventHandler<InputReceivedEventArgs> ReceivedInput = delegate { };
        
        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Excel files (*.xls*)|*.xls*" };
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                ReceivedInput(this, new InputReceivedEventArgs(ofd.FileName));
                sentText = ofd.FileName; 
            }
        }
    }
