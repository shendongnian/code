            bool mouseClick =false;
            private void Form1_Load(object sender, EventArgs e)
            {
                CheckForIllegalCrossThreadCalls = false;
            }
        
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                mouseClick = true;
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
            var x=new Action(doit).BeginInvoke(null,null); //Do something in other thread that UI Thread
            }
        
            private void doit()
            {
                for(soundVolume = 0; soundVolume < 10; soundVolume++)
                {
                  sound.Play();
                 if(mouseClick == true)
                  {
                   soundVolume = 0;
                  }
                }
            }
        }
