    MyFormState[] states = new MyFormState[4];
    Button[] buttons = new Button[4];
    private void Form1_Load(object sender, EventArgs e)
    {
        if (File.Exists("config.xml"))
        {
            loadConfig();
        }
        for (int i = 0; i < 4; ++i)
        {
            buttons[i] = new Button();
            buttons[i].Text = " Equation " + i;
            flowLayoutPanel1.Controls.Add(buttons[i]);
            buttons[i].Click += new EventHandler(btn_Click);
            if (states[i] != null)
            {
                buttons[i].BackColor = ColorTranslator.FromHtml(states[i].ButtonBackColor);
            }
        }
    }
    private void loadConfig()
    {
        XmlSerializer ser = new XmlSerializer(typeof(MyFormState[]));
        using (FileStream fs = File.OpenRead("config.xml"))
        {
            states = (MyFormState[])ser.Deserialize(fs);
        }
    }
    private void writeConfig()
    {
        for (int i = 0; i < 4; i++)
        {
            if (states[i] == null)
            {
                states[i] = new MyFormState();
            }
            states[i].ButtonBackColor = ColorTranslator.ToHtml(buttons[i].BackColor);
        }
        using (StreamWriter sw = new StreamWriter("config.xml"))
        {
            XmlSerializer ser = new XmlSerializer(typeof(MyFormState[]));
            ser.Serialize(sw, states);
        }
    }
