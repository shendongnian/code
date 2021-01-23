        String text;  // your text to read out loud
        String[] parts = text.Split(' ');
        int max = parts.Length;
        int count = 0;
        private String makeSSML() {
            if (count == max) { 
                count= 0;
            }
            String s = "<speak version=\"1.0\" ";
            s += "xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\">";
            for (int i = count; i < max; i++)
            {
                s += parts[i];
                s += "<mark name=\"anything\"/>";
            }
            s += "<mark name=\"END\"/>";
            s += "</speak>";
            return s;
        }
        private void playIT(){
            synth = new SpeechSynthesizer();
            synth.BookmarkReached += synth_BookmarkReached;
            synth.SpeakSsmlAsync(makeSSML());
        }
        private void synth_BookmarkReached(object sender, SpeechBookmarkReachedEventArgs e)
        {
            count++;
            if (e.Bookmark == "END") {
                synth.Dispose();
            }
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            synth.Dispose();
        }
