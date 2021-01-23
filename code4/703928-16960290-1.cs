    namespace OutlookAddIn1
    {
        public partial class Ribbon2
        {
            private void Ribbon2_Load(object sender, RibbonUIEventArgs e) { }
    
            void extract(out String s1, out String s2, out String s3)
            {
                String s1 = String.Empty, s2 = String.Empty, s3 = String.Empty;
                String Body,address,subject;
                Outlook._Application oApp = new Outlook.Application();
                if (oApp.ActiveExplorer().Selection.Count > 0)
                {
                    Object selObject = oApp.ActiveExplorer().Selection[1];
    
                    if (selObject is Outlook.MailItem)
                    {
                        Outlook.MailItem mailItem = (selObject as Outlook.MailItem);
                        subject = mailItem.Subject;
                        address = mailItem.SenderEmailAddress;
                        Body = mailItem.Body;
                        s1 = Body;
                        s2 = address;
                        s3 = subject;
                    }
                }
            }
    
            private void button1_Click(object sender, RibbonControlEventArgs e)
            {
                String s1 = String.Empty, s2 = String.Empty, s3 = String.Empty;
                extract(out s1, out s2, out s3);
                System.Windows.Forms.MessageBox.Show(s1);
                System.Windows.Forms.MessageBox.Show(s2);
                System.Windows.Forms.MessageBox.Show(s3);
            }
    
        }
    }
