    foreach (Button btn in wrpQuestionsMap.Children)
    {
        string name= btn.Content.ToString(); // it must be a number, check it in the debug, and if it is not, Let me know
        if  (name == view.CurrentPosition.ToString())
        {
             btn.Width = 30.0   //change size
             break;             // no need to search more
        }
    }
