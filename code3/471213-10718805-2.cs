    //you need this line to use the tasks
    using System.Threading.Tasks;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Draw()
        {
            Bitmap buffer;
            buffer = new Bitmap(this.Width, this.Height);
            //start an async task
            Task.Factory.StartNew( () =>
            {
                    using (Graphics g =Graphics.FromImage(buffer))
                    {
                        g.DrawRectangle(Pens.Red, 0, 0, 200, 400);
                        //do your drawing routines here
                    }
                //invoke an action against the main thread to draw the buffer to the background image of the main form.
                this.Invoke( new Action(() =>
                {
                        this.BackgroundImage = buffer;
                }));
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //clicking this button starts the async draw method
            Draw();
        }
    }
   
}
