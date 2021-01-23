        private void button1_Click(object sender, System.EventArgs e)
        {
            BackgroundWorker master= new BackgroundWorker();
            master.DoWork += (sender1, e1) =>
                                  {
                                      Thread t1 = new Thread(Func1_class.Start_Test);
                                      Thread t2 = new Thread(Func1_class.Start_Test);
                                      t1.Start();
                                      t2.Start();
                                      t1.Join();
                                      t2.Join();
                                  };
            master.RunWorkerCompleted += (sender2, e2) =>
                                              {
                                                  label1.Text = "text";
                                                  label2.Text = "text";
                                              };
            master.RunWorkerAsync();
        }
