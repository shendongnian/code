        Task myNewTask = SaveMyCurrentStateTask();  //This takes a little while so I want it async in the background
        DialogResult exitResponse = MessageBox.Show("Are you sure you want to Exit MYAPPNAME? ", "Exit Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                
                await myNewTask;
                
                if (exitResponse == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
