    namespace RaceGame
    {
        public partial class Form1 : Form
        {
             Greyhound racing = new Greyhound();
             public Form1()
             {
                InitializeComponent();
             }
    
             private void raceButton_Click(object sender, EventArgs e)
             {
                  racing.runner = this;//assign property here
                  racing.Run();
             }
        }
    }
