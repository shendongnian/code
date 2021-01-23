     var consolidatedList = 
         arrayUserName.Select(
               usrNm => 
                 new {
                       UserName = usrName, 
                       Password = arrayPasswords[arrayUserName.IndexOf(usrName)]
                     }).ToList();
     dataGrid.ItemsSource = consolidatedList;
