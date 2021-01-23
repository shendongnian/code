       public void RandomStatusTypes()
         {
             List<string> statusTypes = new List<string> { "ACTIVE", "INACTIVE", "PROSPECT", "SUSPENDED" };
             Random randStatus = new Random();
             dropList.Items.AddRange(statusTypes);
             dropList.SelectedIndex = randStatus.Next(0, 3);
         }
