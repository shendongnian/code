    public void UpdateFileTransferItems(FileTransferItem.FileTransferRole role)
    {
        if (role == FileTransferItem.FileTransferRole.Sender)
        {
            foreach (var hostSession in fileTransferSessionsAsHost)
            {
                  UpdateTransfers(hostSession);
            }
        }
        else
        {
            foreach (var clientSession in fileTransferSessionsAsClient)
            {
                  UpdateTransfers(clientSession);
            }
        }
    }
    private void UpdateTransfers(SessionBaseType session)
    {
                var fileTransferItem = activeFileTransfers.FirstOrDefault(fti => fti.SessionId == session.Key.SessionId);
                if (fileTransferItem == null)
                {
                    activeFileTransfers.Add(new FileTransferItem(session.Key.FileName,
                                                                 session.Key.FileExtension,
                                                                 session.Key.FileLength,
                                                                 FileTransferItem.FileTransferRole.Sender,
                                                                 session.Key.SessionId));
                }
                else
                {
                    fileTransferItem.Update(session.Value.TotalBytesSent,
                                            session.Value.TransferSpeed,
                                            session.Value.TotalBytesSent == session.Key.FileLength);
                }
    }
