    namespace WindowsFormsApplication26
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                List<first> flist = new List<first>();
                List<second> slist = new List<second>();
    
                flist.Add(new first("apples", 1));
                flist.Add(new first("bananas", 2));
                flist.Add(new first("trees", 3));
    
                slist.Add(new second(1, "Fruit"));
                slist.Add(new second(2, ""));
                slist.Add(new second(3, "Not-Fruit"));
    
                var result = (from t in flist
                              join x in slist
                              on t.ID equals x.ID
                              select new
                              {
                                  Name = t.name,
                                  Id = t.ID,
                                  attrib = x.itemAttr
    
                              }).ToList();
            }
    
    
            public class first
            {
                public first()
                {
    
                }
    
                public first(string n, int id)
                {
                    name = n;
                    ID = id;
                }
    
                public string name { get; set; }
                public int ID { get; set; }
    
            }
    
            public class second
            {
                public second()
                {
    
                }
    
                public second(int id, string itm)
                {
                    ID = id;
                    itemAttr = itm;
                }
    
                public int ID { get; set; }
                public string itemAttr { get; set; }
            }
        }
    }
