	    private void button1_Click(object sender, EventArgs e)
        {
            ALTER A = new ALTER();
            this.TextBox1.Text = A.ALTER();
        }
    }
	
	[...]
    public class ALTER
    {
        public String ALTER()
        {
			// Do your thing
			
            return "I Altered That";
        }
    }
