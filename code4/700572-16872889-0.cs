    MessageCollection tmp = go_client.GetAllMessageHeaders(inbox);
    
    foreach (ImapMessage msg in tmp.Take(100))
    {
        ImapMessage actual_message = go_client.GetMessageText(msg.UID,      go_Folders_As_Tree.Children[1]);
    }
