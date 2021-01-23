    public partial class Form1 : Form
    {
        private Character _character;
        public Form1(Character character)
        {
            _character = character;
        }
        public void pictureBox1_Click(object sender, EventArgs e)
        {
            If (_character.hair_black)
            {
                 ...
            }
        }
    }
    ...
    var deviljin = new Character()
    {
        hair_black = true
    };
    Application.Run(new Form1(deviljin));
