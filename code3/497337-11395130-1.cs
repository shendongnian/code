        IReadOnlyList<String> text;
        string finalt = "";  //for space
        private async void Recognize_Click(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<InkRecognitionResult> x = await _inkManager.RecognizeAsync(InkRecognitionTarget.All);
            foreach (InkRecognitionResult i in x)
            {
                text = i.GetTextCandidates();
                finalt += " " + text[0];
                res.Text = finalt;  //res is the x:Key for the text block
            }
        }
