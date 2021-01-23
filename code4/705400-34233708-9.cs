      internal class Class1 : MainWindow //(3) Inherited
        {
          internal void Display()
            {
               MessageBox.Show(Main.TextBox1.Text); //(4) Access MainWindow Controls by adding 'Main' before it.
             }
         }
