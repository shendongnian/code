        private void button3_Click(object sender, EventArgs e)
        {
            GetSomething()
                .ContinueWith(task =>
                    {
                        if (task.IsCanceled)
                        {
                        }
                        else if (task.IsFaulted)
                        {
                            var ex = task.Exception.InnerException;
                            MessageBox.Show(ex.Message);
                        }
                        else if (task.IsCompleted)
                        {
                            var list = task.Result;
                            foreach (int i in list)
                            {
                                listView1.Items.Add(new ListViewItem(i.ToString()));
                            }
                        }
                    });
        }
