    public class Account
    {
        public string Number { get; set; }
        public string Description1 { get; set; }
    
        public bool EmptyItem { get; private set; }
        public string DisplayText
        {
            get{return this.Number + "-" + this.Description1}
        }
    }
    this.comboboxAccount.DisplayMember = "DisplayText";
