    List<string> searchSplit = txtSearch.Text.ToLower().Split(' ');
    var found = (from User in myDB.Memberships
             where IsMatch(searchSplit, User)
    private bool IsMatch(List<string> searchSplit, User User){
       return searchSplit.Count() ==
              searchSplit.Where(x => User.Name.ToLower().Contains(x) ||
                                     User.Surname.ToLower().Contains(x)).Count();
    }
