    public class Form1 : FOrm {
    
    private int x = 15;
    
    private void button1_Click(object sender, EventArgs e)
        {
    
            Button c = new Button();
            c.Location = new Point(x,40);
            c.Text = "novo";
            panel1.Controls.Add(c);
    
            x += 10 + c.Size.Width;
        }
    }
