    private Player _player;
    
    private void hit_Click(object sender, EventArgs e) {
        // Add the first card
        _player.Cards.Add(Hit.GenerateID(..));
        // Add the second card
        _player.Cards.Add(Hit.GenerateID(..));
        ...
        // In order to use sum you will need: using System.Linq;
        this.test.Text = _player.Cards.Sum().ToString();
    }
    
    public class Player {
        public Player () {
            Cards = new List<int>();
        }
    
        public List<int> Cards { get; private set; }
    }
