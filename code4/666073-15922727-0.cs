    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        // This is the program start. Probably the place that would have loaded the plug ins.
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
        //Form goes in project one and has a reference to Interfaces.
        public class MainForm : Form, IMainForm
        {
            private TextBox _textBox;
            private IPlugIn _thePlugIn;
            private Button _aButton;
            public MainForm()
            {
                InitializeComponent();
                _thePlugIn = ObtainPlugInsThroughMagic();
            }
            private IPlugIn ObtainPlugInsThroughMagic()
            {
                // So this would usually go off and load some DLLs and then instantiate the IPlugIn objects
                // We're cheating.
                var plugin = new MyPlugIn();
                plugin.Initialise(this);
                return plugin;
            }
            public void SetTextBoxValueFromPlugIn(string newText)
            {
                _textBox.Text = newText;
            }
            private void InitializeComponent()
            {
                _textBox = new TextBox();
                _aButton = new Button();
                SuspendLayout();
                _aButton.Location = new Point(20, 50);
                _aButton.Size = new Size(100, 25);
                _aButton.TabIndex = 1;
                _aButton.Click += AButtonClick;
                _aButton.Text = "Fire plug in";
                _textBox.Location = new Point(20, 10);            
                _textBox.Size = new Size(260, 20);
                _textBox.TabIndex = 0;
                AutoScaleDimensions = new SizeF(6F, 13F);
                AutoScaleMode = AutoScaleMode.Font;
                ClientSize = new Size(300, 100);
                Controls.Add(_textBox);
                Controls.Add(_aButton);
                Text = "Main form";
                ResumeLayout(false);
                PerformLayout();
            }
            private void AButtonClick(object sender, System.EventArgs e)
            {
                _thePlugIn.MakePlugInDoItsStuff();
            }
        }
        #region interfaces go in the new Interfaces project.
    
        public interface IMainForm
        {
            void SetTextBoxValueFromPlugIn(string newText);
        }
        public interface IPlugIn
        {
            void Initialise(IMainForm mainForm);
            void MakePlugInDoItsStuff();
        }
        #endregion
        // The plug in goes in the plug in project and has a reference to Interfaces.
        public class MyPlugIn : IPlugIn
        {
            public IMainForm MainForm { get; private set; }
            public void Initialise(IMainForm mainForm)
            {
                MainForm = mainForm;
            }
            public void MakePlugInDoItsStuff()
            {
                MainForm.SetTextBoxValueFromPlugIn("Text set from plug in");
            }
        }
    }
