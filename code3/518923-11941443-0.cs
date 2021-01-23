    public class DropDownModel
    {
        public IEnumerable<string> DropDownOptions
        {
            get;
            set;
        }
    
        public DropDownModel()
        {
        }
    
        public DropDownModel(IEnumerable<string> dropDownOptions)
        {
            DropDownOptions = dropDownOptions;
        }
    }
    public class ConditionalsModel
    {
        public IEnumerable<string> ConditionalAnalysisInput
        {
            get;
            set;
        }
    
        public ConditionalsModel()
        {
        }
    
        public ConditionalsModel(string selectedOption)
        {
            if (selectedOption == "Option A")
            {
                ConditionalAnalysisInput = new List<string>
                {
                    "Input A 1",
                    "Input A 2",
                    "Input A 3"
                };
            }
            else if (selectedOption == "Option B")
            {
                ConditionalAnalysisInput = new List<string>
                {
                    "Input B 1",
                    "Input B 2",
                    "Input B 3"
                };
            }
        }
    }
