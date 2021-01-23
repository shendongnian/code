    System.Windows.Forms.Timer keyManagerTimer = new System.Windows.Forms.Timer();
    int count = 0;
    public Form1()
    {
        InitializeComponent();
        this.keyManagerTimer.Tick += (s, e) => ProcessKeys();
        this.keyManagerTimer.Interval = 25;
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if ((keyData & Keys.Right) != 0)
        {
            keyManagerTimer.Enabled = true;
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
    private void ProcessKeys()
    {
        bool isShiftKeyPressed = IsKeyPressed(Keys.ShiftKey);
        bool isRightKeyPressed = IsKeyPressed(Keys.Right);
        if (isRightKeyPressed && !isShiftKeyPressed)
        {
            count++;
        }
        else if (isRightKeyPressed && isShiftKeyPressed)
        {
            count += 10;
        }
        label.Text = "count = " + count.ToString();
    }
    public static bool IsKeyPressed(Keys key)
    {
        return BitConverter.GetBytes(GetKeyState((int)key))[1] > 0;
    }
    [DllImport("user32")]
    private static extern short GetKeyState(int vKey);
