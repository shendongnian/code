    void ChangeArrayDisplay(int firstColumn) //Any column can be first, from 0 to 7
    {
        int k = 0;
        for (int i = firstColumn * 4; i < stringLength; i++) 
        {
            changeOvalColor(k, toto[i]);
            k++;
        }
        for (int i = 0; i < firstColumn * 4; i++) 
        {
            changeOvalColor(k, toto[i]);
            k++;
        }
    }
    void ChangeOvalColor(int index, int colorValue)
    {
         if(colorValue == 0)
             ovalShape[index].FillColor = Color.Red;
         else
             ovalShape[index].FillColor = Color.LawnGreen;
    }
