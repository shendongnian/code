    namespace WindowsFormsApplication1
    {
        public class Game
        {
            public string Name { get; set; }
            public string Group { get; set; }
        }
    
        public class Group
        {
            public string Description { get; set; }
        }
    
        public partial class Form1 : Form
        {
            List<Game> _allGames;
            
            public Form1()
            {
                InitializeComponent();
    
                _allGames = new List<Game>
                {
                    new Game { Name = "Alpha", Group = "" },
                    new Game { Name = "Bravo", Group = "One" },
                    new Game { Name = "Charlie" , Group = "One"},
                    new Game { Name = "Delta", Group = "Two" }
                };
    
                bindingSource1.DataSource = _allGames;
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
    
                var groups = new List<Group>
                {
                    new Group { Description = "One" },
                    new Group { Description = "Two" },
                    new Group { Description = "Three" }
                };
    
                bindingSource2.DataSource = groups;
                listBox2.DisplayMember = "Description";
                listBox2.ValueMember = "Description";
            }
    
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                var group = listBox2.SelectedValue.ToString();
                bindingSource3.DataSource = _allGames.Where(x => x.Group == group);
                listBox3.DisplayMember = "Name";
            }
        }
    }
