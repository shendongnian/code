    bool CheckInputReady(params TextBox[] txtBoxes)
    {
        bool inputReady = true;
        for (int i = 0; i < txtBoxes.Length; i++)
        {
            if (String.IsNullOrEmpty(txtBoxes[i].Text))
            {
                inputReady = false;
                break;
            }
        }
        return inputReady;
    }
