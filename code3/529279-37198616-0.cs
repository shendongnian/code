    while (num_winners == 0)
            {
                for (int i = 0; i < Dogs.Length; i++)
                {
                    if (Dogs[i].Run())
                    {
                        num_winners++;
                        winner = i + 1;
                    }
                }
                Application.DoEvents();
                System.Threading.Thread.Sleep(3);
            }
            if (num_winners > 1)
     // you say that you have multiple winners right here but you never eval on 
     //it - winner is still set to one value above
                MessageBox.Show("We have " + num_winners + " winners"); 
            else
                MessageBox.Show(" Dog #" + winner + "wins!");
            for (int i = 0; i < Dogs.Length; i++)
            {
                Dogs[i].TakeStartingPosition();
            }
            for (int i = 0; i < Bettors.Length; i ++)
            {
                Bettors[i].Collect(winner);
                Bettors[i].ClearBet();
                Bettors[i].UpdateLabels();
            }
