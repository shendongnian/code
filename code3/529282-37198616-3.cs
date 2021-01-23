    private void formButtonRace_Click(object sender, EventArgs e)
        {
            int winner = 0;
            int windog = 0;
            int count = 0;
            for (int i = 0; i < Bettors.Length; i++)
            {
                if (Bettors[1].MyBet != null)
                {
                    count++;
                }
            }
            if (count == Bettors.Length)
            {
                while (winner == 0)
                {
                    for (int i = 0; i < Dogs.Length; i++)
                    {
                        if (Dogs[i].Run())
                        {
                            winner++;
                            windog = i + 1;
                            for (int i2 = 0; i2 < Bettors.Length; i2++)
                            {
                                Bettors[i2].Collect(i + 1);
                            }
                        }
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(3);
                    }
                }
                if (winner > 1)
                {
                    MessageBox.Show("Multiple winners!", "WOW");
                }
                else
                {
                    MessageBox.Show("The winner was dog #" + windog);
                }
                for (int i = 0; i < Bettors.Length; i++)
                {
                    Bettors[i].ClearBet(true);
                }
                for (int i = 0; i < Dogs.Length; i++)
                {
                    Dogs[i].TakeStartingPosition();
                }
            }
            else
            {
                MessageBox.Show("Not all players have placed their bets!", "Wait wait!");
            }
        }
