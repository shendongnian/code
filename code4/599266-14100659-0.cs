            if (inputTextBoxes != null && inputTextBoxes.Count > inputNumber)
            {
                int removecount = inputTextBoxes.Count - inputNumber;
                for (int i = 0; i < removecount; i++)
                {
                    TextBox t = inputTextBoxes[inputTextBoxes.Count+i];
                    t.Dispose();
                }
                return;
            }  
