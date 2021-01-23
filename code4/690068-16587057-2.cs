    public partial class Form1 : Form
    {
        string[] chars = new string[]
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = BuildString(150);
            var g = this.label1.CreateGraphics();
            var size = g.MeasureString(filePath, this.Font);
            var oneCharacterLen = (size.Width / (float)filePath.Length);
            if (size.Width > ((float)this.label1.Width - (oneCharacterLen * 3f)))
            {
                this.label1.Text = CutoffStringBinSearch(g, string.Format("{0}", filePath), 0, this.label1.Width);
            }
        }
        private string CutoffStringBinSearch(Graphics g, string s, int startIndex, int maxWidth)
        {
            var midPoint = (s.Length - startIndex) / 2;
            var subString = string.Format("{0}...", s.Substring(startIndex, midPoint));
            var len = g.MeasureString(subString, this.Font);
            if (len.Width > (float)maxWidth) { return CutoffStringBinSearch(g, s.Substring(startIndex, midPoint), 0, maxWidth); }
            return subString;
        }
        private string BuildString(int len)
        {
            string[] s = new string[len];
            var random = new Random(0);
            for (int i = 0; i < len; i++)
            {
                s[i] = chars[random.Next(0, chars.Length - 1)];
            }
            return string.Join("", s);
        }
    }
