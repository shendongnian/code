    var query = db.invites.AsQueryable();
    
    if(!string.IsNullOrEmpty(userInput.Division.Text))
        query = query.Where(invite => invite.Division == userInput.Division.Text);
    
    if(!string.IsNullOrEmpty(userInput.Status.Text))
        query = query.Where(invite => invite.Status== userInput.Status.Text);
