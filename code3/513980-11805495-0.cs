    System.Threading.Thread thread = new System.Threading.Thread(() =>
                    {
                        SyncDatabase.GetInstance.DoWhatYouWant();
    
                    });
    thread.Start();
