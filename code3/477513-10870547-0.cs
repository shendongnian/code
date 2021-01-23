    public class EnforceBusinessRules
    {
        BusinessState m_state;
    
        public EnforceBusinessRules(IEnumerable<Rule> rules)
        {
            m_state = START;
        }
    
        public void Enforce(string input)
        {
            foreach (var rule in rules)
            {
                m_state = rule.EnforceRule(input);
            }
        }
    }
    
    public interface Rule
    {
        public BusinessState EnforceRule(string input);
    }
    
    public class IsInputcurrentlyFormatted : Rule
    {
        public BusinessState EnforceRule(string input)
        {
            //code goes here to ensure the input passes formatting test
        }
    }
    
    public class InputContainsValidStartAndEndTokens : Rule
    {
        public BusinessState EnforceRule(string input)
        {
            //code goes here to ensure the input passes formatting test
        }
    }
    
    public class StartEndCommandisValidAccordingtoCurrentSystemSettings : Rule
    {
        public BusinessState EnforceRule(string input)
        {
            //code goes here to ensure the input passes formatting test
        }
    }
    
    // and so on
 
