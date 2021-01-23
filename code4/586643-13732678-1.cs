    private void button_Click(object sender, EventArgs e){
       string n = ((Button)sender).Text;
       int number;
       if(int.TryParse(n, out number)){
          if(number % 2 == 0)
             MessageBox.Show(n + "  is divisible by 2");
          else 
             MessageBox.Show(n + "  isn't divisible by 2");
       }
    }
