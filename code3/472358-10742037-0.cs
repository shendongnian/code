    public class TemplatingService : ITemplatingService
    {
        public string GenerateReminderMessage(string to, string name)
        {
            // Construct the template, passing in the parameters into the session as required
            ...
            // Return the results of the template transformation
        }
    }
