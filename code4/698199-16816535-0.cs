    namespace DataGridViewList
    {
       public partial class Form1 : Form
       {
         public struct LocationEdit
         {
           public string Key { get; set; }
           private string _value;
           public string Value { get { return _value; } set { _value = value; } }
         };
         public Form1()
         {
           InitializeComponent();
           BindingList<LocationEdit> list = new BindingList<LocationEdit>();
           list.Add(new LocationEdit { Key = "0", Value = "Home" });
           list.Add(new LocationEdit { Key = "1", Value = "Work" });
           dataGridView1.DataSource = list;
         }
         //CellParsing event handler for dataGridView1
         private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e){
            LocationEdit current = ((BindingList<LocationEdit>)dataGridView1.DataSource)[e.RowIndex];
            string key = current.Key;
            string value = current.Value;
            string cellValue = e.Value.ToString()
            if (e.ColumnIndex == 0) key = cellValue;
            else value = cellValue;
            ((BindingList<LocationEdit>)dataGridView1.DataSource)[e.RowIndex] = new LocationEdit {Key = key, Value = value};
         }
       }
    }
