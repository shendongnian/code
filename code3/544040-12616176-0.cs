    int pointsAvarded = 0;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        pointsAvarded = 0; //so you can be sure to use the latest input
        int userInput = 0;
        if (int.TryParse(textBox1.Text, out userInput))
          switch (userInput)
          {
              case 0:
                points = 5;
                break;
              case 1:
                points = 10;
                break;
              ...
              default:
                points = 40;
                break;
          }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (pointsAvarded != 0)
          MessageBox.Show("You have been awarded" + pointsAvarded + "points");
    }
