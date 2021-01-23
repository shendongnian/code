        private void RollDiebutton_Click(object sender, EventArgs e)
        {
            //-------------------------
            //-------------------------
         
            WriteScore();
    
            //-------------------------
            //-------------------------
        }
        private void WriteScore(string score)
        {
            File.AppendAllLines(sd, new string[]{ score });
        }
