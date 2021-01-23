     private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt || e.Control || e.Shift))
            {
                // Display a pop-up Help topic to assist the user.
                Help.ShowPopup(textBox1, "Enter your name.", new Point(textBox1.Bottom, textBox1.Right));
            }
        }
