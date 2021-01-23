        private GridViewColumn NewGridViewColumn(string header, string bindingName)
        {
            GridViewColumn gvc = new GridViewColumn();
            gvc.Header = header;
            gvc.DisplayMemberBinding = new Binding(bindingName);            
            return gvc;
        }
