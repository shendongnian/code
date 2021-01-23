    private void button1_click(object sender, EventArgs e)
    {
         // Error Handling
         
         TemperatureConverter tc = new TemperatureConverter();
         tc.Conversion(textbox1.Text, textbox2.Text);
    }
