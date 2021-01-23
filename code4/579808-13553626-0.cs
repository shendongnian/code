    private void BUEquals_Click(object sender, EventArgs e)
            {
              1:  input2 = float.Parse(TBAnswer.Text);
              2:  if (choice == 0)
              3:      TBAnswer.Text = (input1 + input2).ToString();
              4:  else if (choice == 1)
              5:      TBAnswer.Text = (input1 - input2).ToString();
              6:      TBStored.Text = TBStored.Text + '-' + (input2).ToString();
