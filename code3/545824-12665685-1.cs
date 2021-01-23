    public List<Button> avail = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
    public Button Ran()
    {
        Random b1 = new Random();
        int index = b1.Next(avail.Count); 
        if (index > 0) {
            return avail[index];
        } else {
            return null;
        }
    }
    public void buttonchange(Button b)
    {
        if(b != null) {
            if (b.Content.ToString() == "") {
                b.Content = x ? "X" : "O";
                x = !x;
            }
            avail.Remove(b);
        }
    }
