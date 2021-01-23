       private void LoadInterface()
       {
           DatabaseHandle testing = new DatabaseHandle();
           IEnumerable<string> teammembers = testing.PopulateTeamMembers();
           foreach(string value in teammembers)
           {
               comboBoxResolvedBy.Items.Add(value);
           }
       }
