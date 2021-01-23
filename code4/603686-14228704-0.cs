    private void GetRandColor()
        {
            Random r = new Random(DateTime.Now.Millisecond);
    
            System.Drawing.Color[] colours = 
            {
                System.Drawing.Color.Yellow, 
                System.Drawing.Color.LightGreen, 
                System.Drawing.Color.LightCyan,
                System.Drawing.Color.LightSalmon,  
                System.Drawing.Color.LightSkyBlue
            };
    
            int i = r.Next(0, colours.Length - 1);
    
            System.Drawing.Color c = colours[i];
    
            Button1.BackColor = c;
        }
