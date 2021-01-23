                if (choice == 0)
                    TBAnswer.Text = (input1 + input2).ToString();
                else if (choice == 1)
                {
                    TBAnswer.Text = (input1 - input2).ToString();
                    TBStored.Text = TBStored.Text + '-' + (input2).ToString();
                }
                else if (choice == 2)
                    TBAnswer.Text = (input1 * input2).ToString();
                else
                    TBAnswer.Text = (input1 / input2).ToString();
