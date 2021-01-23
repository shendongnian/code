    public static Form1 Instance { get; private set; }
    // You still need this like in the first scenario.
    public RichTextBox PrintCtrl1 { get { return richTextBoxPrintCtrl1; } }
    // This constructor should already exist. Just add the one line to it.
    public Form1()
    {
        Instance = this;
    }
