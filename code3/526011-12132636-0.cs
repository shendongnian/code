    public void startbtn_Click(object sender, RoutedEventArgs e)
    {
        engine.resetSequence(); // Start from sequence 0
        // Animate first button
        animate(engine.animate()); 
    }
    private void animate(int index)
    {
        // Storyboard for each button is in the format of ButtonAnimation_INDEX where INDEX is 1, 2, 3 or 4
           Storyboard btnAnimation = (Storyboard)this.Resources["ButtonAnimation_" + index];
           // Added completed event function handler
           btnAnimation.Completed += btnAnimation_Completed;
           if (btnAnimation != null)
           {
               btnAnimation.Begin();   
            }
    }
    void btnAnimation_Completed(object sender, EventArgs e)
    {
         // If another button can be animated in the sequence
         if (engine.CurrentSequence() < engine.getCurrentLevel())
         {
             // Increment the sequence position
             engine.nextSequence();
             // Run the animation with the next button
             animate(engine.animate());
         }
    }
