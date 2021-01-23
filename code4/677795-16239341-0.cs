     private void interval_ValueChanged(object sender, EventArgs e)
        {
            int seconds = intervaloDP.Value.Hour * 3600 + intervaloDP.Value.Minute * 60 + intervaloDP.Value.Second;
            // finalDP.Value = finalDP.Value.AddSeconds(seconds); //wrong
            finalDP.Value = startDP.Value.AddSeconds(seconds); 
        }
