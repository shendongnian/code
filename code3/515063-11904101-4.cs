    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyHolder holder = new MyHolder();
            for (int i = 0; i < 3; i++)
            {
                holder.Objects.Add(new MyObjType1 { Id = i, Name = i + "Name" });
            }
            for (int i = 0; i < 3; i++)
            {
                holder.Objects.Add(new MyObjType2 { Reference = "Ref" + i });
            }
            propertyGrid1.SelectedObject = holder;
        }
    }
