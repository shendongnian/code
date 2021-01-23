     public class ParameterSelector
    {
     
        private Dictionary<string,Action> _dictActionMap = new Dictionary<string, Action>();
        public ParameterSelector()
        {
            PopulateDictionaryWithActions();
        }
        private void PopulateDictionaryWithActions()
        {
            _dictActionMap.Add("LastName", () => lastName = txtBox_Value);
            _dictActionMap.Add("MiddleName", () => middleName = txtBox_Value);
        }
     }
