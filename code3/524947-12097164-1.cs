    namespace WindowsFormsApplication1
    {
        public class MyClass
        {
            public string Something { get; set; }
            public UserFrienlyEnum foo { get; set; }
        }
        public enum UserFrienlyEnum
        {
            [Description("it need spec training")]
            SPECIAL_TRAINING = 1,
            [Description("it need normal training")]
            NORMAL_TRAINING = 2,
            [Description("it need simple training")]
            SIMPLE_TRAINING = 3
        }
        public partial class Form1 : Form
        {
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                setEnumValues(this.comboBox1, typeof(UserFrienlyEnum));
                MyClass variable = new MyClass();
                variable.foo = UserFrienlyEnum.NORMAL_TRAINING;
                this.comboBox1.SelectedValue = (int)variable.foo;
    
            }
    
            public static void setEnumValues(ComboBox cxbx, Type typ)
            {
                if (!typ.IsEnum)
                {
                    throw new ArgumentException("Only Enum types can be set");
                }
    
                List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
    
                foreach (int i in Enum.GetValues(typ))
                {
                    string name = Enum.GetName(typ, i);
                    string desc = name;
                    FieldInfo fi = typ.GetField(name);
    
                    // Get description for enum element
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0)
                    {
                        string s = attributes[0].Description;
                        if (!string.IsNullOrEmpty(s))
                        {
                            desc = s;
                        }
                    }
    
                    list.Add(new KeyValuePair<string, int>(desc, i));
                }
                // NOTE: It is very important that DisplayMember and ValueMember are set before DataSource.
                //       If you do, this works fine, and the SelectedValue of the ComboBox will be an int
                //       version of the Enum.
                //       If you don't, it will be a KeyValuePair.
                cxbx.DisplayMember = "Key";
                cxbx.ValueMember = "Value";
                cxbx.DataSource = list;
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
    
        }
    }
