        public class MyService
        {        
            public void CreateDebitRequest(int userId, int cardId, decimal Amount, .... , IValidationDictionary validationDictionary)
              {
                    if(userId == 0)
                        validationDictionary.AddError("UserId", "UserId cannot be 0");
              }
         }
