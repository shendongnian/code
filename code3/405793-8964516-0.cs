    private void randomMove()
    {
        bool foundEmpty = false;
        for (int i = 0; i < 3; i++)
        {
            for (int a = 0; a < 3; a++)
            {
                if (Board[a,i] == "")
                {
                    Board[a,i] = "O";
                    Temp = i + a;
                    compMove(Temp);
                    foundEmpty = true;
                    break;
                }  
            }
            if (foundEmpty)
               break;
        }
    }
