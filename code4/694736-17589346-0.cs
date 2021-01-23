    private void readMails(){
            MailServer oServer=new MailServer("imap.gmail.com", "something@gmail.com", "noneedtoseethis", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("Client");
            oServer.SSLConnection = true;
            oServer.Port = 993;
            try {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                Console.WriteLine(infos.Length);
                for (int i = 0; i < infos.Length; i++){
                    MailInfo info = infos[i];
                    Mail oMail = oClient.GetMail(info);
    
                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    //oClient.Delete(info);
                }
                oClient.Quit();
            } catch (Exception ep) {
                Console.WriteLine(ep.Message);
            }
        }
