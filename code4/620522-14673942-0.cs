    Random r = new Random();
    private void Draw()
    {
        // Create 4 random numbers
        int[] numbers = Enumerable.Range(0, 4).Select(x => r.Next(0, 300)).ToArray();
        System.Drawing.Graphics g = this.CreateGraphics();
        Pen green = new Pen(Color.Green, 5);
        g.DrawLine(green, new Point(numbers[0], numbers[1]),
                          new Point(numbers[2], numbers[3]));
    }
