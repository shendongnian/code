    enum MyState { Part1, Part2, Part3 }
    MyState currentState = Part1;
    int clickCount = 0;
    public void tasbih()
    {
        // First, do state transitions.
        switch(currentState)
        {
            case MyState.Part1:
                if(clickCount >= 34) { currentState = MyState.Part2; clickCount = 0; } 
                break;
            case MyState.Part2:
                if(clickCount >= 33) { currentState = MyState.Part3; clickCount = 0; } 
                break;
            case MyState.Part3:
                if(clickCount >= 33) { currentState = MyState.Part1; clickCount = 0; } 
                break;
        }
        // Now, act on the current (or new) state.
        switch(currentState)
        {
            case MyState.Part1:
                textBlock1.Text = "TEXTBX 1";
                textBlock2.Text = clickCount.ToString();
                break;
            case MyState.Part2:
                textBlock1.Text = "TEXTBX 2";
                textBlock2.Text = clickCount.ToString();
                break;
            case MyState.Part3:
                textBlock1.Text = "ZZZZ";
                textBlock2.Text = clickCount.ToString();
                break;
        }
    }
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        currentState = MyState.Part1;
        clickCount = 0;
        tasbih();
    }
