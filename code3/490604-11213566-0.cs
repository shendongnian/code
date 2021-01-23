    // pseudocode 
    class Person 
       int PersonID 
       IEnumerable<IQuestionResponse> QuestionResponses
    //non generic interface to allow all QuestionRespones 
    //to be stored in one typed collection
    interface IQuestionResponse
        
    class QuestionResponse<TResponse> : IQuestionResponse
       Question<TResponse> Question
       IEnumerable<TResponse> Responses
    class Question<TResponse>
       string QuestionText 
       IEnumerable<TResponse> AllowedResponses 
       bool AllowsMultipleResponses
