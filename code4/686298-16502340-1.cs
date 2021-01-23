    var customTableSource = new CustomTableSource(myList);
    MyTable.Source = customTableSource;
    customTableSource.ListItemSelected += (object sender, EventArgs e) => {
         if((e as MyCustomEventArgs).rowSelected == 1){
              this.NavigationController.PushViewController(new MyNextViewController(), true));
         }
    }
