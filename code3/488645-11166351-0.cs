    public partial class ClassName
    {
        Graphics g;        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            Pen main = new Pen(Color.Black);
            g.DrawRectangle(main, vars.x, vars.y, 2, 2);
        }
        
    }
