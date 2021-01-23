    private MyPerson bozo { get; set; }
    public void Form1_Load(object sender, EventArgs e)
    {
        bozo = new MyPerson("bozo",48,23);
        textBox2.Text = bozo.name;
    }
    public void button1_Click(object sender, EventArgs e)
    {
        bozo.myMethod(); // now you can access since it "lives" in the whole form
    }
