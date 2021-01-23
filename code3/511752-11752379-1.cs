    void timer_Tick(object sender, EventArgs e){
        if(i < word.Lenght){
           string audio = words[i];
           if( audio == "a" ) {
               SoundPlayer sndplayr = new SoundPlayer( WindowsFormsApplication1.Properties.Resources.aa );
               sndplayr.Play();   
           }
           if( audio == "u" ) {
               SoundPlayer sndplayr = new SoundPlayer( WindowsFormsApplication1.Properties.Resources.i );
               sndplayr.Play();
           }
    
           i++; //increase i to change letter like in the loop
        }
        else{
           timer.Enabled = false; //stop the timer
           i = 0;
        }
    }
