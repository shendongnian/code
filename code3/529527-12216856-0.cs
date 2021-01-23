    protected void OrderPeriodStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
          String value = DropDownListnew.SelectedValue;
          Console.Write(value); //You retrieve your selected value
         string text = DropDownListnew.SelectedItem.Text;
         Console.Write(text); //You retrieve your selected text
        }
