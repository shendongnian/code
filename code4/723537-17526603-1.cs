    List<string> searchSplit = txtSearch.Text.ToLower().Split(' ');
    var found = (from User in myDB.Memberships
             where IsMatch(searchSplit, User)
    private bool IsMatch(List<string> searchSplit, User User){
       foreach (string word in searchSplit){
           if (User.Name.ToLower().Contains(word) ||
               User.Surname.ToLower().Contains(word))
           {
              return true;
           }
       }
       return false;
    }
