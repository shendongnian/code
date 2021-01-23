        public partial class Form1 : Form
    {
        public enum MyEnum
        {
            EnumValue1,
            EnumValue2,
            EnumValue3
        }
        public class EnumExtension
        {
            public MyEnum enumValue;
            public String enumString;
            public EnumExtension(MyEnum enumValue, String enumString)
            {
                this.enumValue = enumValue;
                this.enumString = enumString;
            }
            public override string ToString()
            {
                return enumString;
            }
        }
        private EnumExtension[] extendedEnumerations =
        {
            new EnumExtension(MyEnum.EnumValue1, "Enum Value 1"),
            new EnumExtension(MyEnum.EnumValue2, "Enum Value 2"),
        };
        public Form1()
        {
            InitializeComponent();
            foreach (EnumExtension nextEnum in extendedEnumerations)
                comboBox1.Items.Add(nextEnum);
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnumExtension selectedExtension = (EnumExtension)comboBox1.SelectedItem;
            MyEnum selectedValue = selectedExtension.enumValue;
        }
    }
