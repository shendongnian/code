        private Dictionary<string, List<string>> opposites;
        private Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
        private void StartSpeechRecognition(Media_Slide slide)
        {
            if (opposites == null)
            {
                opposites = new Dictionary<string, List<string>>();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                string file = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(MainWindow)).CodeBase).Remove(0, 6) + "\\buzzlist.xml";
                doc.Load(file);
                foreach (System.Xml.XmlNode node in doc.ChildNodes[1].ChildNodes)
                {
                    opposites.Add(node.Name, new List<string>(node.Attributes[0].InnerText.Split(',')));
                    words.Add(node.Name, new List<string>(node.InnerText.Split(',')));
                }
            }
            speechSlide = slide;
            rec = new SpeechRecognitionEngine();
            rec.SpeechRecognized += rec_SpeechRecognized;
            rec.SetInputToDefaultAudioDevice();
            try
            {
                rec.LoadGrammar(GetGrammar());
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
            }
        }
