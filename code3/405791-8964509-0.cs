    private void randomMove()
    {
        Boolean finish = false;
        for (int i = 0; i < 3; i++)
        {
            for (int a = 0; a < 3; a++)
            {
                if (Board[a,i] == "")
                {
                    Board[a,i] = "O";
                    Temp = i + a;
                    compMove(Temp);
                    finish = true;
                    break;
                }  
            }
            if (finish) break;
        }
    }
    private void randomMove()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int a = 0; a < 3; a++)
            {
                if (Board[a,i] == "")
                {
                    Board[a,i] = "O";
                    Temp = i + a;
                    compMove(Temp);
                    goto Finish;
                }  
            }
        }
        Finish: return;
    }
