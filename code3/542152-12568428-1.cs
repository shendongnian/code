    GridViewColumn gvc = new GridViewColumn();
    gvc.DisplayMemberBinding = new Binding("Surname");
    gvc.Header = "Surname";
    gvc.Width = 100;
    myGridView.Columns.Add(gvc);
