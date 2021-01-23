    private void button2_Click_1(object sender, EventArgs e)
        {
            prog.stuff(this);
        }
        public void Updateprogressbar(int input)
        {
            progressBar1.Value = input;
    
        }
    
    
     public static void stuff(Form f)
        {
            int up = 100;
            f.Updateprogressbar(up);
        }
