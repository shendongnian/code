        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        
        namespace ValidationWPF.DataSources
        {
            public class ValidationMessage
            {
                public ValidationMessage(string name, string Message)
                {
                    this.Message = Message;
                    this.PropertyName = name;
                }
        
                public string Message
                {
                    get;
                    set;
                }
        
                public string PropertyName { get; set; }
        
            }
        }
    
    VALIDATIONVIEWMODEL CLASS:
    
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Collections.ObjectModel;
        
        namespace ValidationWPF.DataSources
        {
            public class ValidationViewModel
            {
                public ValidationViewModel()
                {
                    this.Errors = new ObservableCollection<ValidationItem>();
        
                    ValidationItem item = new ValidationItem();
                    item.Description = "Customer";
        
                    ValidationMessage msg = new ValidationMessage("FirstName", "First name is required");
                    item.Messages.Add(msg);
        
        
                    this.Errors.Add(item);
        
                    ValidationItem item2 = new ValidationItem();
                    item2.Description = "Order";
        
                    msg = new ValidationMessage("Quantity", "Quantity must be greater than zero");
                    item2.Messages.Add(msg);
        
        
                    item.SubItems.Add(item2);
        
                }
        
                public ObservableCollection<ValidationItem> Errors { get; set; }
            }
        }
