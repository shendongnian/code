    using System;
    using S22.Imap;
    namespace Test {
    class Program {
        static void Main(string[] args)
        {
            using (ImapClient Client = new ImapClient("imap.gmail.com", 993,
             "username", "password", Authmethod.Login, true))
            {
                // This returns all messages sent since August 23rd 2012
                uint[] uids = Client.Search(
                    SearchCondition.SentSince( new DateTime(2012, 8, 23) )
                );
                // Our lambda expression will be evaluated for every MIME part
                // of every mail message in the uids array
                MailMessage[] messages = Client.GetMessages(uids,
                    (Bodypart part) => {
                     // We're only interested in attachments
                     if(part.Disposition.Type == ContentDispositionType.Attachment)
                     {
                        Int64 TwoMegabytes = (1024 * 1024 * 2);
                        if(part.Size > TwoMegabytes)
                        {
                            // Don't download this attachment
                            return false;
                        }
                     }
                     // fetch MIME part and include it in the returned MailMessage instance
                     return true;
                    }
                );
            }
        }
    }
    }
