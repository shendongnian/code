    const int DELTA_PERCENT = 10;
    List<Color> alreadyChoosenColors = new ArrayList<Color>();
    
    // initialize the random generator
    Random r = new Random();
    
    for (int i = 0; i < 20; i++)
    {
        bool chooseAnotherColor = true;      
        while ( chooseAnotherColor )
        {
           // create a random color by generating three random channels
           //
           int redColor = r.Next(0, 255);
           int greenColor = r.Next(0, 255);
           int blueColor = r.Next(0, 255);
           Color tmpColor = Color.FromArgb(redColor, greenColor, blueColor);  
        
           // check if a similar color has already been created
           //
           chooseAnotherColor = false;
           foreach (Color c in alreadyChoosenColors)
           {
              int delta = c.R * DELTA_PERCENT / 100;
              if ( c.R-delta <= tmpColor.R && tmpColor.R <= c.R+delta) )
              {
                 chooseAnotherColor = true;
                 break;
              }
    
              delta = c.G * DELTA_PERCENT / 100;
              if ( c.G-delta <= tmpColor.G && tmpColor.G <= c.G+delta) )
              {
                 chooseAnotherColor = true;
                 break;
              }
    
              delta = c.B * DELTA_PERCENT / 100;
              if ( c.B-delta <= tmpColor.B && tmpColor.B <= c.B+delta) )
              {
                 chooseAnotherColor = true;
                 break;
              }
            }
        }
    
        alreadyChoosenColors.Add(tmpColor);
        // you can safely use the tmpColor here
        
       }
