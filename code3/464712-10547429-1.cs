    string[] sSplitedText = sEnteredText.Split(' '); //Because many letters can be entered with sapce as delimiter 
    foreach(string sNewStr in sSplitedText)
                {
                    if (lMyDictionary.ContainsKey(sNewStr))
                    {
                        sReturnText += lMyDictionary[sNewStr];
                    }
                }
                ResultDisplayTextBox.Text = sReturnText;
