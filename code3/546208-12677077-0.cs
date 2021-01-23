    //Store the first possible name.
    var possibleUsername = string.Format("{0}{1}", tbLname.Text, tbFname.Text.Substring(0,1))
    //Don't hit the database N times, instead get all the possible names in one shot.
    var existingUsers = entities.Users.Where(u => u.Username.StartsWith(possibleUsername).ToList();
    //Find the first possible open username.
    if (existingUsers.Count == 0) {
        //Create the user since the username is open.
    } else {
        //Iterate through all the possible usernames and create it when a spot is open.
        for(var i = 1; i < existingUsers.Count; i++) {
            if (existingUsers.FirstOrDefault(u => u.Username == string.Format("{0}{1}", tbLname.Text, tbFname.Text.Substring(0, i))) == null) {
                //Create the user since the user name is open.
            }
        }
    }
