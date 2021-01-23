    private void AddResistor_Click(object sender, EventArgs e)
        {
            resistors.Add(new Resistor());
            Console.WriteLine("Added a Resistor...");
            Canvas.Invalidate();
        }
