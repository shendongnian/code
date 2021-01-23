    public class Form1 : Form
    {
        private void SomeEventHandler(object sender, EventArgs args)
        {
            string result = await Task.Run(()=>new PrintClass().DoWork());
            TboxPrint.AppendText(result);
        }
    }
