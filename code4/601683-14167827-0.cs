     private void Form1_Load(object sender, EventArgs e)
                { 
        
                       for (int i = 0; i < 2; i++)
                          {
                             for (int j = 0; j < 2; j++)
                             {
                                b[i, j].Click += new System.EventHandler(this.ClickedButton);
                                b[i, j].Name =i+" "+j;
                              }
                          }
                }
        private void ClickedButton(object sender, EventArgs e)
                {
                    
                    Button s = (Button)sender;
                    MessageBox.Show("you have clicked button:" + s.Name);
                }
