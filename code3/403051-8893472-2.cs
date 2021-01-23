    class ComboboxItem
    {
      public int Value { get; set; }
      public string Description { get; set; }
    }
    public partial class Form1 : Form
    {
      List<ComboboxItem> ComboBoxItems = new List<ComboboxItem>();
      public Form1()
      {
        InitializeComponent();
        ComboBoxItems.Add(new ComboboxItem() { Description = "Default = 0", Value = 0 });
        ComboBoxItems.Add(new ComboboxItem() { Description = "Value 1 = 1", Value = 1 });
        ComboBoxItems.Add(new ComboboxItem() { Description = "Value 2 = 2", Value = 2 });
        comboBox1.DataSource = ComboBoxItems;
        comboBox1.DisplayMember = "Value";
                
      }
        
      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
      {
        var item = (ComboboxItem)((ComboBox)sender).SelectedItem;
        var test = string.Format("Description is \'{0}\', Value is  \'{1}\'", item.Description, item.Value.ToString());
        MessageBox.Show(test);
      }
    }
