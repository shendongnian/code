     Transactions t = new Transactions{
            Comments = textbox_taskcomments.Text,
            By = UserID,
            Name = Name,
            IssuedOn = DateTime.Now,
            StatusID = StatusID
     };
     //check that the entity does not yet contain t
     if(!Form.Transactions.Contains(t)){
     //do something.
     }
