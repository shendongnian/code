    namespace reademail
    {
     static class Program
    {
        public static Microsoft.Office.Interop.Outlook.Application myApp;
        public static void Main(string[] args)
        {
            // myApp = new Microsoft.Office.Interop.Outlook.Application();
            //myApp.NewMailEx += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_NewMailExEventHandler(OutlookNewMailReceived);
            ReadMail();
        }
        static void ReadMail()
        {
            Microsoft.Office.Interop.Outlook.Application app = null;
            Microsoft.Office.Interop.Outlook._NameSpace ns = null;
            //Microsoft.Office.Interop.Outlook.MailItem item = null;
            Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
            app = new Microsoft.Office.Interop.Outlook.Application();
            ns = app.GetNamespace("MAPI");
            //ns.Logon(null, null, false, false);
            inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            // subFolder = inboxFolder.Folders["Inbox"]; //folder.Folders[1]; also works
            Console.WriteLine("Folder Name: {0}, EntryId: {1}", inboxFolder.Name, inboxFolder.EntryID);
            Console.WriteLine("Num Items: {0}", inboxFolder.Items.Count.ToString());
            //System.IO.StreamWriter strm = new System.IO.StreamWriter("C:/Test/Inbox.txt");
            for (int counter = 1; counter <= inboxFolder.Items.Count; counter++)
            {
                Console.Write(inboxFolder.Items.Count + " " + counter);
                dynamic item = inboxFolder.Items[counter];
                //item = (Microsoft.Office.Interop.Outlook.MailItem)inboxFolder.Items[counter];
                Console.WriteLine("Item: {0}", counter.ToString());
                Console.WriteLine("Subject: {0}", item.Subject);
                Console.WriteLine("Sent: {0} {1}", item.SentOn.ToLongDateString(), item.SentOn.ToLongTimeString());
                Console.WriteLine("Sendername: {0}", item.SenderName);
                Console.WriteLine("Body: {0}", item.Body);
                //strm.WriteLine(counter.ToString() + "," + item.Subject + "," + item.SentOn.ToShortDateString() + "," + item.SenderName);
            }
            //strm.Close();
        }
    }
}
