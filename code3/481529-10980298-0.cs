        Thread chatRefreshTimer;
        void StartChat()
        {
            chatRefreshTimer = new Thread(new ThreadStart(ChatRefresh));
            chatRefreshTimer.Start();
        }
        void ChatRefresh()
        {
            conn = new MySqlConnection("Server=...; Database=...; Uid=...; Password=...;");
            ds.Clear();
            da.SelectCommand = conn.CreateCommand();
            da.SelectCommand.CommandText = "select * from chatmessagetbl";
            da.SelectCommand.CommandType = CommandType.Text;
            while (true)
            {
                da.Fill(ds, "chatmessagetbl");
                textBlockChatArea.Text = "";
                foreach (DataRow item in ds.Tables["chatmessagetbl"].Rows)
                {
                    //This has to be done on the thread that owns the textbox.
                    textBlockChatArea.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            textBlockChatArea.Text += item["username"].ToString() + ": " + item["message"].ToString() + "\n";
                        }));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            conn.Dispose();
        }
