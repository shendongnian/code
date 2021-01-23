    public partial class Form2 : Form
    {
        delegate void SetTextCallback(string text);
        delegate void CloseFormCallback();
        public Form2()
        {
            InitializeComponent();
            new Thread(DoMagic).Start();
        }
        public void DoMagic()
        {
            this.SetText("Start.");
            Thread.Sleep(1000);
            this.SetText("Counting.");
            Thread.Sleep(1000);
            this.SetText("End");
            Thread.Sleep(1000);
            this.CloseForm();
        }
        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                CloseFormCallback c = new CloseFormCallback(CloseForm);
                this.Invoke(c);
            }
            else
            {
                this.Close();
            }
        }
        private void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }
        }
    }
