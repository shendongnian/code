    public partial class Form1 : Form {
        private readonly ColorPropertyObject cpo = new ColorPropertyObject();
        private Action<Color> colorSetter;
        private readonly Dictionary<RadioButton, Action<Color>> setterDictionary =
            new Dictionary<RadioButton, Action<Color>>();
        public Form1() {
            InitializeComponent();
            setterDictionary.Add(radioButton1, c => cpo.Color1 = c);
            setterDictionary.Add(radioButton2, c => cpo.Color2 = c);
            setterDictionary.Add(radioButton3, c => cpo.Color3 = c);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            colorSetter = setterDictionary[(RadioButton)sender];
        }
        private void button1_Click(object sender, EventArgs e) {
            colorSetter(Color.Blue);
        }
        private void button2_Click(object sender, EventArgs e) {
            colorSetter(Color.Black);
        }
        private void button3_Click(object sender, EventArgs e) {
            colorSetter(Color.Red);
        }
        private void button4_Click(object sender, EventArgs e) {
            Console.WriteLine(cpo.Color1 + " - " + cpo.Color2 + " - " + cpo.Color3);
        }
    }
    public class ColorPropertyObject {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }
    }
