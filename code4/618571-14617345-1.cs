    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
        writeConfig();
    }
    private void writeConfig() {
        using (StreamWriter sw = new StreamWriter("config.xml")) {
            state.ButtonBackColor = System.Drawing.ColorTranslator.ToHtml(button1.BackColor);
            XmlSerializer ser = new XmlSerializer(typeof(MyFormState));
            ser.Serialize(sw, state);
        }
    }
