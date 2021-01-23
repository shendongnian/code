    		public void setText(string text)
            {
                if (ChatClient.ChatClient.client.Controls[0].InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(setText);
                    client.Invoke(d, new object[] { text });
                }
                else
                {
                    client.Controls[0].Text = null;
    
                    for (int i = 0; i < chat.Length - 1; i++)
                    {
                        chat[i] = chat[i + 1];
                    }
    
                    chat[30] = text;
    
                    for (int i = 0; i < chat.Length; i++)
                    {
                        client.Controls[0].Text += chat[i] + "\r\n";
                    }
    }
