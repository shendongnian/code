    foreach pictureBox in someContainer.ChildControls
    {
        var user = ReturnUser(pictureBox);
        if (user != null)
        {
            usersFirstRow.Add(user);
        }
    }
