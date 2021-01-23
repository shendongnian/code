    /// <summary>
    /// Gets or sets the answers to the view state
    /// </summary>
    private List<int> Answers
    {
        get
        {
            // attempt to load the answers from the view state
            var viewStateAnswers = ViewState["Answers"];
    
            // if the answers are null, or not a list, create a new list and save to viewstate
            if (viewStateAnswers  == null || !(viewStateAnswers  is List<int>))
            {
                Answers = new List<int>();
            }
    
            // return the answers list
            return (List<int>)viewStateAnswers;
        }
        set
        {
            // saves a list to the view state
            var viewStateAnswers = ViewState["Answers"];
        }
    }
