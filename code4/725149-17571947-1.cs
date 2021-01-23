    private void btnValdiate_Click(object sender, EventArgs e)
        {           
            decimal value;
            
            if(Decimal.TryParse(textBox1.Text,out value))
            {
                bool check = TwoDecimalPlaces(value);
                 if(check )
                  {
                   //do something 
                  }else
                  {
                   //do something else
                   }
            }else
            {
              // do something 
            }
        }
        private bool TwoDecimalPlaces(decimal dec)
        {
            decimal value = dec * 100;
            return value == Math.Floor(value);
        }
