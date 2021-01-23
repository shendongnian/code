     private void Quiz_Load(object sender, EventArgs e)
        {
            displayQs();
        }
        
        private void displayQs()
        {
                Random _random = new Random();
                int z = _random.Next(Questions.Count);
                QuizData q = (QuizData)Questions[z];
                Qslbl.Text = q.Quest;
                DisplayAns(q, _random);
        }
        private void DisplayAns(QuizData q, Random _random)
        {
            int j = 0;
            int[] array = new int[4];
            for (int i = 0; j <= 3; i++)
            {
                int x = _random.Next(4);
                x++;
                if (array.Contains(x))
                {
                    continue;
                }
                else
                {
                    array[j] = x;
                    j++;
                    string answer = null;
                    if (j == 1)
                        answer = q.RightAnswer;
                    else if (j == 2)
                        answer = q.WrongAnswer1;
                    else if (j == 3)
                        answer = q.WrongAnswer2;
                    else if (j == 4)
                        answer = q.WrongAnswer3;
                    if (x == 1)
                        radioButton1.Text = answer;
                    else if (x == 2)
                        radioButton2.Text = answer;
                    else if (x == 3)
                        radioButton3.Text = answer;
                    else if (x == 4)
                        radioButton4.Text = answer;
                }
            }
        }
