    Sounds like homework to me... just in case it isn't:
    private int direction = 1;
    private int speed = 10;
    
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        direction = 1;
        timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        if( label1.Left + label1.Width > this.Width && direction == 1 ){
            direction = -1;
        }
        if( label1.Left <= 0 && direction == -1 ){
            direction = 1;
        }
        label1.Left = label1.Left + (direction * speed);
    }
