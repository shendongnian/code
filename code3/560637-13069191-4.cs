        public abstract class Item
        {
         public virtual string Name { get; set; }
         public virtual int Cost { get; set; }
        }
        public  class ConcItem:Item
        {
         public override string Name { get; set; }
         public override int Cost { get; set; }        
        }
        public  class FooterItem:Item 
        {
         public override string Name { get { return "Total"; } }
         public override int Cost { get; set; }
        }
        public class ItemList : List<Item>
        {
          private Item _footer;
          public void SetFooter()
          {
           _footer = new FooterItem();            
            foreach (var item in this)
            {
            _footer.Cost += item.Cost;              
            }
          this.Add(_footer);
        }
        }
         public partial class Form1 : Form
         {
           Item _item;
          ItemList _itemList;
          public Form1()
          {
             InitializeComponent();
            dgv.DataBindingComplete += dgv_DataBindingComplete;
            _itemList = new ItemList();
            SetSampleData();
        }
        private void SetSampleData()
        {
         _item = new ConcItem();
         _item.Name = "Book";
         _item.Cost = 250;
         _itemList.Add(_item);
         _item = new ConcItem();
         _item.Name = "Table";
        _item.Cost = 500;
        _itemList.Add(_item);
        _item = new ConcItem();
        _item.Name = "PC";
        _item.Cost = 700;
        _itemList.Add(_item);
        dgv.DataSource = null;
        _itemList.SetFooter();  //Add the footer item b4  data binding
        dgv.DataSource = _itemList;
            
        }
        void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        //If you want to do some formating on the footer row
         int rowIndex = dgv.Rows.GetLastRow(DataGridViewElementStates.Visible);
        if (rowIndex <= 0)
        {
         return;
         }
          dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
          dgv.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.Red; 
