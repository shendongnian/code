    public class User 
    {
        public double Balance { get;set; }
        public ValidationMessageCollection ValidatePayout(double withdrawAmount)
        {
            var messages = new ValidationMessageCollection();
            if (withdrawAmount > Balance)
            {
                messages.AddError("Not enough funds on your account");
            }
            return messages;
         }
         public void Payout(double withdrawAmount)
         {
             balance -= withdrawAmount;
         }
     }
