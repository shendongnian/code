        void MoneyEntry()
        {
            SetCurrentUser();
            MoneyEntryViewModel money = new MoneyEntryViewModel(_currentPerson);
            this.Workspaces.Add(money);
            this.SetActiveWorkspace(money);
        }
