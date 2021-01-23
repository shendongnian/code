    public partial class Form1 : Form
    {
        private List<Actor> _actors;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
    
    
        public void LoadData()
        {
            _actors = new List<Actor>
        {
            new Actor(){ PersonId = 1, ForNavn = "xxxx", EtterNavn = "bbbbb", Adresse = "Hhhhhh", PostNr = 37325, PostSted = "aaaa" },
            new Actor(){ PersonId = 2, ForNavn = "ggggg", EtterNavn = "ddddd", Adresse = "Dssssss", PostNr = 37464, PostSted = "ssfff"  },
        };
        }
    
    
        private void btnSok_Click(object sender, EventArgs e)
        {
    
            var query = from actor in _actors
                        select actor;
    
            dataGridView1.DataSource = query.ToList();
    
        }
    }
