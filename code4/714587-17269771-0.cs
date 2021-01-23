    public class myClass
    {
      private string key;
      private string val;
      public string Key
      {
         get
         {
            return key;
         }
         set
         {
            key = value;
         }
      }
      public string Value
      {
         get
         {
            return val;
         }
         set
         {
            val = value;
         }
      }
      public myClass(string newKey, string newVal)
      {
         key = newKey;
         val = newVal;
      }
    }
       public partial class Form1 : Form
    {
      List<myClass> list = new List<myClass>(); 
      public Form1()
      {
         InitializeComponent();
         list.Add(new myClass("a","aa"));
         list.Add(new myClass("b", "bb"));
         list.Add(new myClass("v", "vv"));
         comboBox1.DataSource = list;
         comboBox1.DisplayMember = "Key";
         comboBox1.ValueMember = "Value";
      }
    }
