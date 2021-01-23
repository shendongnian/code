    private Queue<Color> colors = new Queue<Color>();
    public Form1()
    {
        InitializeComponent();
    
        //Here you set the order that the colors will be set in.
        colors.Enqueue(System.Drawing.Color.Black);
        colors.Enqueue(System.Drawing.Color.Red);
        colors.Enqueue(System.Drawing.Color.Gray);
        colors.Enqueue(System.Drawing.Color.Blue);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        textbox1.BackColor = colors.Peek();
    
        //move the color at the front to the back of the queue
        colors.Enqueue(colors.Dequeue());
    }
