     Boolean isok =true;
            public void Jogger()  {
                int ii=0;
                long sec = System.Environment.TickCount;
                while (isok)
                {
                    if (sec + 1000  < System.Environment.TickCount)
                    {
                        sec = System.Environment.TickCount;
                        //replace with your code
                        ii += 1;
                        textBox1.Text = ii.ToString();
    
                    }
                        Application.DoEvents(); 
                }
            }
