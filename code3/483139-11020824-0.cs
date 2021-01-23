    // Calls the getter and returns a new list
    List<string> questions = VisibleQuestions; 
    // Updates the list, but does not trigger the setter
    questions.Add(sqc.SurveyQuestion.ID); 
    // Calls the setter
    VisibleQuestions = questions;
