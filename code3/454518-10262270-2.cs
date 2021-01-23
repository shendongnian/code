    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
              if(Button != null && this.Controls.Contains(myText))
              {
                   this.Controls.Remove(myText);
                   myText.Dispose();
              )
        }
    }
