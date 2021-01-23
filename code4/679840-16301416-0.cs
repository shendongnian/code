    private void btn_choose_Click(object sender, EventArgs e)
    {
        int action = Convert.ToInt32(nud_cat_chooser.Value);
        this.DequeuePlayer(action); 
    }
    /// <summary>
    /// Recursivly called until there is no more cards
    /// </summary>
    private void DequeuePlayer(int action)
    {
        // switch statement to take the user input and decide the outcome.
        switch (action)
        {
            case 1:
                if (Convert.ToInt32(lbl_p1_cat_1_value.Text) == Convert.ToInt32(lbl_p2_cat_1_value.Text))
                {
                    MessageBox.Show("Stalemate");//message box to inform the user of a statemate.
                    playingcards card1 = player1.Dequeue();//creates tempoary instance of the abstract class playign cards to store the cards
                    playingcards card2 = player2.Dequeue();//creates tempoary instance of the abstract class playign cards to store the cards
                    assign_Values();
                    this.DequeuePlayer(action);
                }
            ....
        }
