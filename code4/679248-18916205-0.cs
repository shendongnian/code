        private SpeechSynthesizer reader = new SpeechSynthesizer();
        private void PopulateInstalledVoices()
        {
            foreach (InstalledVoice voice in
              reader.GetInstalledVoices(new CultureInfo("en-US")))
            {
                VoiceInfo info = voice.VoiceInfo;
                comboBox1.Items.Add(info.Name);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateInstalledVoices();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           var voice = comboBox1.SelectedItem as String;
           if (voice != null)
           {
               reader.SelectVoice(voice);
           }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reader.SpeakAsync("this is a test message");
        }
