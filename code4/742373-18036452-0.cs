    private void textBox2_KeyUp(object sender, KeyEventArgs e)
    {
         if (e.Key == Key.Delete)
         {
              if (textBox2.Text.Length == 0)
              {
              Keyboard.Focus(textBox1);
              }
         }
    }
