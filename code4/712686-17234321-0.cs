    class Company{ 
                   string Name{get; set;} 
                   string address{get;set;} 
                   IList<BankAccount> Accounts{get; set;}
                 } 
    class BankAccount{
                       Company CompanyName{get; set;} 
                       string BankName{get; set;} 
                       string AccountNo{get; set;} 
                       string BankAddress{get; set;}
                     } 
    On create page for company i create and delete dynamically new BankAccount information by taking entry in Table's <td> cell having inputbox.
    I have to bind the List of newly created BankAccount to the CompanyModel on view page
