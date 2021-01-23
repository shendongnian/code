    [XmlType("response")]
    public class Response
    {
        [XmlElement("response_error_dialogs")]
        public ErrorDialog ErrorDialog;
    }
    
    [XmlType("response_error_dialogs")]
    public class ErrorDialog
    {
        [XmlArray("error_dialog_list")]
        public List<ChoiceErrorDialog> ChoiceList;
    }
    
    [XmlType("error_dialog_choice")]
    public class ChoiceErrorDialog
    {
        [XmlElement("error_dialog_id")]
        public int Id;
    
        [XmlElement("error_dialog_message")]
        public string Message;
    
        [XmlElement("error_dialog_title")]
        public string Title;
    
        [XmlElement("error_dialog_is_set")]
        public bool IsSet;
    
        [XmlArray("error_dialog_choice_option_list")]
        public List<Option> OptionList;
    }
    
    [XmlType("error_dialog_choice_option")]
    public class Option
    {
        [XmlElement("error_dialog_choice_option_id")]
        public int Id;
    
        [XmlElement("error_dialog_choice_option_title")]
        public string Title;
    }
