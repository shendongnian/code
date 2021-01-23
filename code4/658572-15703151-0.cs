    namespace Spaceship_Invaders
    {
        public partial class Form1 : Form
        {
    		private Spaceship _myspaceship;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                _myspaceship = new spaceship();
                this.textBox1.Text = myspaceship.mspaceship();
            }
        }
    	
    	public class Spaceship
    	{
    		public string mspaceship()
    		{              
    			return " working";               
    		}
    	}
    }
