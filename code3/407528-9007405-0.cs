        public class ActionResult<T>
        {
            public T Result { get; set; }
            public bool IsSuccessful { get; set; }
            public string DetailMessage { get; set; }
            //Any other properties you might find useful like statuscode, etc.
        }
        public ActionResult<Packet> ParsePacket(string input)
        {
            Packet result = null;
            bool parseSuccess = true;
            string message = null;
            // Do your work, create packet and check conditions. 
            // Assign to your local variables.
            return new ActionResult<Packet> { 
                Result = result, 
                IsSuccessful = parseSuccess, 
                DetailMessage = message 
            };
        }
        public void SomeCallingMethodLikeGetPacket(string userInput)
        {
            ActionResult<Packet> parseResult = ParsePacket(userInput);
            if (!parseResult.IsSuccessful)
            {
                //Error handling.
            }
            else
            {
                Packet packet = parseResult.Result;
                //Do something with packet.
            }
        }
