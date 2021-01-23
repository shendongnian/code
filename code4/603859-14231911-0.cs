    public void AddUserIfNotNull(User user) {
        if (user != null)
            usersFirstRow.Add(user);
    }
    // ... then ...
    public void IteratePictureBoxesAndAddUsers(List<PictureBox> pictureBoxes) { // <-- feel free to rename
        foreach (PictureBox p in pictureBoxes) {
            AddUserIfNotNull(ReturnUser(p));
        }
    }
