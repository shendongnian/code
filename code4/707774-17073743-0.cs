    Task.Factory.ContinueWhenAll(tasks, f =>
                {
                    if (t1.Exception != null)
                    {
                         // t1 had an exception
                    }
                    if (t2.Exception != null)
                    {
                         // t2 had an exception
                    }
                    // This is called when both tasks are complete, but is called
                    // regardless of whether exceptions occured.
                    MessageBox.Show("All tasks completed");
                });
