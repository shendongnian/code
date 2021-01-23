    string CheckWinnerHorizontal(Button[] buttonArray) {
        int N = (int)Math.Sqrt(buttonArray.Length);
        for (int row = 0; row < N; ++row)
        {
            string winner = "";
            for (int col = 0; col < N; ++col)
            {
                string value = buttonArray[row * N + col].Text;
                if (winner == "") { winner = value; }
                else if (winner != value { winner = "none"; }
            }
            if (winner != "none" && winner != "")
            {
                return winner;
            }
        }
        return "";
