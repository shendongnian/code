    private void Form1_Load(object sender, EventArgs e) {
        if (File.Exists("config.xml")) {
            loadConfig();
        }
        button1.BackColor = System.Drawing.ColorTranslator.FromHtml(state.ButtonBackColor);
    }
    private void loadConfig() {
        XmlSerializer ser = new XmlSerializer(typeof(MyFormState));
        using (FileStream fs = File.OpenRead("config.xml")) {
            state = (MyFormState)ser.Deserialize(fs);
        }
    }
