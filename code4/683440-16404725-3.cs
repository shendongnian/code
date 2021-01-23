    public partial class myUserControl:UserControl
    {
       public TextBox TxtName{ get{ return txtBox1;}}
       
       public ListBox CustomListBoxName
       {
          get
          {
             return ListBox1;
          }
          set
          {
             ListBox1 = value;
          }
       }
       
       public List<object> DataSource {get;set;}
    } 
