	    void tb_TextChanged(object sender, EventArgs e)
	    {
              //Remove previous formatting, or the decimal check will fail
	      string value = tb.Text.Replace(",", "").Replace("$", "");
	      decimal ul;
              //Check we are indeed handling a number
	      if (decimal.TryParse(value, out ul))
	      {
                //Unsub the event so we don't enter a loop
	        tb.TextChanged -= tb_TextChanged;
                //Format the text as currency
	        tb.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
	        tb.TextChanged += tb_TextChanged;
	      }
	    }
