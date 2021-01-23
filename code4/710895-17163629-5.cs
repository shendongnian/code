    public class Form1 : Form {
        public Form1(){
           ControlAdded += FormControlAdded;
           InitializeComponent();
        }
        private void FormControlAdded(object sender, ControlEventArgs e){
            Binding bind = new Binding("Font", this, "Font");
            bind.Format += (s, ev) =>
            {
                Font inFont = (Font)ev.Value;
                Binding bin = (Binding)s;
                ev.Value = new Font(bin.Control.Font.FontFamily, inFont.Size, bin.Control.Font.Style);
            };
            e.Control.DataBindings.Clear();
            e.Control.DataBindings.Add(bind);
        }
    }
