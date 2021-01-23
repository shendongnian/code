    public class spaceship
    { 
        Image myimage = Image.FromFile("image/Untitled6.png");
        Form1 myform = new Form1();
        
        spaceship()
        {
            myform.pictureBox1.Image = myimage;             
        }
    }
