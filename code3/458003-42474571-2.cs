     public List<HistoryDetails> GetAllHistoryDetails()
            {
                List<HistoryDetails> myHistoryDetails = new List<HistoryDetails>();
                try
                {
                    myHistoryDetails = BusinessLogic.GetAllHistoryDetails(IdVal);                
                }
                catch(Exception ex)
                {
                    
                }
                return myHistoryDetails;
            } 
