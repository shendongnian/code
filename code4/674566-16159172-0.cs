      private void Btn_Hello(object sender, RoutedEventArgs e)
      {
          RadioButton rb = selection.Items.OfType<RadioButton>().FirstOrDefault(o => o.IsChecked==true);
          if(rb!=null)
              Hello_box.Text = "hello" + rb.Content.ToString();
      }
