      KeyDownHandler()
      {
          MessageBox.Show("Some Message");
          // or if you need something with more flexiblity
          OtherForm of = new OtherForm();
          OtherForm.Show();
          string someVal = OtherForm.TextBox.Text;
          MethodThatNeedsInputFromTextBox(int.Parse(TextBox.Text));
      }
