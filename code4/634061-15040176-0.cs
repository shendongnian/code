     int[] numbers = new int[2];  // Declare the array 
     public void Button1_Click() {
        numbers[0] = Int32.Parse(TextBox1.Text);
        numbers[1] = Int32.Parse(TextBox2.Text);
        numbers[2] = Int32.Parse(TextBox3.Text);
        TextBox4.Text = numbers.Sum().ToString();
     }
