    public static async Task<bool> UpdateInvitation(string senderID, string readerName, string senderDeviceID)
        {
            try
            {
                IMobileServiceTable<TASLS_WAMS_INVITATIONS> invitationsTable = App.MobileService.GetTable<TASLS_WAMS_INVITATIONS>();
        
                var invitationRecordToUpdate =
                    invitationsTable.Where(i => i.SenderID == senderID).
                                     Where(i => i.ReaderName == readerName).
                                     Take(1).ToListAsync();
        
                    await invitationsTable.UpdateAsync(invitationRecordToUpdate[0]);
            }
            catch (Exception)
            {
                return false;
            }
            return true; // If no exception, assume record was inserted successfully
        }
