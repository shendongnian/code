        List<CommonFormBase> activeWindows = new List<CommonFormBase>();
        public void LaunchApplication(ApplicationWindowType formTypeToLaunch)
        {
            CommonFormBase tempForm;
            switch (formTypeToLaunch)
            {
                //implement code to create a new form here
            }
            activeWindows.Add(tempForm);
            tempForm.Name = "UniqueName:" + System.DateTime.Now;
            tempForm.FormClosed += new FormClosedEventHandler(tempForm_FormClosed);
            tempForm.Show();
        }
        void tempForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is CommonFormBase)
            {
                //Get the index of the selected form
                int index = -1;
                for (int i = 0; i <= this.activeWindows.Count - 1; i++)
                {
                    if (this.activeWindows[i].Name == ((Form)sender).Name)
                        index = i;
                }
                //Remove the selected form from the list
                if (index >= 0)
                    activeWindows.RemoveAt(index);
                //Close the TaskbarUtility if no remaining windows
                //  and user choose to exit when none remain
                if (this.activeWindows.Count == 0 && CloseTaskbarWhenNoRemainingWindows)
                {
                    this.Close();
                }
            }
        }
