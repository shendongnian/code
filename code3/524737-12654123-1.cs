    private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail 
            string value = String.Format("{0:0,0.00}", double.Parse(textBox8.Text));
     // "12,345.87"
 
            
            decimal ul;
            //Check we are indeed handling a number 
            if (decimal.TryParse(value, out ul))
            {
                //Unsub the event so we don't enter a loop 
                textBox8.TextChanged -= textBox8_TextChanged;
                //Format the text as currency 
                textBox8.Text = value.ToString();
                textBox8.TextChanged += textBox8_TextChanged;
            }
        }
