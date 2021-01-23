    public partial class Form1 : Form
    {
        List<ComboData> data;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            data = new List<ComboData>();
            data.Add(new ComboData(1, "BigBox", "Boxes larger than 6x6"));
            data.Add(new ComboData(2, "SmBox", "Boxes small than 6x6"));
            data.Add(new ComboData(3, "BirBrl", "Barrel 55 Gallons"));
            data.Add(new ComboData(4, "smBrl", "Barrel less than 55 gallons"));
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "ShortNm";
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            comboBox1.DisplayMember = "LongNm";
            comboBox1.SelectedIndex = i;
    
    
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;
            int newWidth;
            foreach (ComboData s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s.LongNm, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            comboBox1.DisplayMember = "ShortNm";
            comboBox1.SelectedIndex = i;
        }
    }
    public class ComboData
    {
        public int Code;
        public string ShortNm
        {
            get;
            set;
        }
        public string LongNm
        {
            get;
            set;
        }
        public ComboData(int c, string s, string l)
        {
            Code = c;
            ShortNm = s;
            LongNm = l;
        }
    }
