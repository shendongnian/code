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
            new EnumExtension(MyEnum.EnumValue3, "Enum Value 3"),  
        };  
        public Form1()  
        {  
            InitializeComponent();  
            foreach (EnumExtension nextEnum in extendedEnumerations)  
                comboBox1.Items.Add(nextEnum);  
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);  
  
            button1.Click += new EventHandler(button1_Click);  
            button2.Click += new EventHandler(button2_Click);  
            button3.Click += new EventHandler(button3_Click);  
        }  
  
        void button3_Click(object sender, EventArgs e)  
        {  
            comboBox1.SelectedItem = extendedEnumerations[2];  
        }  
  
        void button2_Click(object sender, EventArgs e)  
        {  
            SetSelectedEnumeration(MyEnum.EnumValue2);  
        }  
  
        void button1_Click(object sender, EventArgs e)  
        {
            SetSelectedEnumeration(MyEnum.EnumValue1);
        }
        private void SetSelectedEnumeration(MyEnum myEnum)
        {
            foreach (EnumExtension nextEnum in comboBox1.Items)
            {
                if (nextEnum.enumValue == myEnum)
                {
                    comboBox1.SelectedItem = nextEnum;
                    break;
                }
            }
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnumExtension selectedExtension = (EnumExtension)comboBox1.SelectedItem;
            MyEnum selectedValue = selectedExtension.enumValue;
        }
    }
