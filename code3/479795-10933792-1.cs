    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using log4net.Appender;
    using log4net.Core;
    using log4net.Layout;
    
    namespace SampleAppendersApp.Appender
    {
        public class CustomSmtpAppender : AppenderSkeleton
        {
            /// <summary>
            /// mail appender that sends individual messages
            /// </summary>
            /// <remarks>
            /// This sends each LoggingEvent received as a
            /// separate mail message.
            /// The mail subject line can be specified using a pattern layout.
            /// </remarks>
    
            public string SmtpServerName { get; set; }
            public string SmtpServerUserName { get; set; }
            public string SmtpServerPassword { get; set; }
            public string SmtpPortNumber { get; set; }
            public short SmtpServerConnectionLimit { get; set; }
            public bool SmtpServerUsingNtlm { get; set; }
            public bool SmtpServerRequiredLogin { get; set; }
    
            public void Send(string fromMailAdress, string toMailAdress, string ccMailAdress,string bccMailAdress, string subject, string body)
            {
                MailAddress _fromMailAddress;
                List<MailAddress> toMailAdressList;//= new List<MailAddress>();
                var ccMailAdressList = new List<MailAddress>();
                var bccMailAdressList = new List<MailAddress>();
                //string subject = "";
                //string body = string.Empty;
                _fromMailAddress = new MailAddress(fromMailAdress); //TODO: "swapneel.deshpande@travelex.com"
                toMailAdressList = GetToMailAddress(toMailAdress); //TODO: "TODO@travelelx.com"
    
                ccMailAdressList = GetToMailAddress(ccMailAdress);
    
                MailAddress bccMailAddress = _fromMailAddress;
    
                bccMailAdressList.Add(bccMailAddress);
                Send(_fromMailAddress, toMailAdressList, ccMailAdressList, bccMailAdressList, subject, body);
            }
    
            private static List<MailAddress> GetToMailAddress(string emailList)
            {
                return emailList.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(cEmail => new MailAddress(cEmail, "TRS", Encoding.UTF8)).ToList();
            }
    
            public void Send(MailAddress from, List<MailAddress> to, List<MailAddress> cc, List<MailAddress> bcc, string subject, string body)
            {
                MailMessage mailMessage = GetMailMessage(subject, body, from, to, cc, bcc);
                SendEmail(mailMessage);
            }
    
            private static MailMessage GetMailMessage(string subject, string body, MailAddress from,
                                              IEnumerable<MailAddress> to, IEnumerable<MailAddress> cc, IEnumerable<MailAddress> bcc)
            {
                var mailMessage = new MailMessage
                {
                    From = from,
                    Subject = subject,
                    Body = body
                };
    
                foreach (MailAddress toAddress in to)
                {
                    mailMessage.To.Add(toAddress);
                }
    
                if (cc != null)
                {
                    foreach (MailAddress ccAddress in cc)
                    {
                        if (ccAddress != null)
                        {
                            mailMessage.CC.Add(ccAddress);
                        }
                    }
                }
    
                if (bcc != null)
                {
                    foreach (MailAddress bccAddress in bcc)
                    {
                        if (bccAddress != null)
                        {
                            mailMessage.Bcc.Add(bccAddress);
                        }
                    }
                }
                return mailMessage;
            }
    
            private SmtpClient GetSmtpClient()
            {
                var client = new SmtpClient
                {
                    Credentials =
                        (!String.IsNullOrEmpty(SmtpHost))
                            ? GetNetworkCredentials(SmtpServerPassword, SmtpServerUserName)
                            : CredentialCache.DefaultNetworkCredentials,
                    Host = SmtpHost
                };
    
                return client;
            }
    
            private static NetworkCredential GetNetworkCredentials(string password, string userName)
            {
                return new NetworkCredential
                {
                    Password = password,
                    UserName = userName
                };
            }
    
            private void SendEmail(MailMessage message)
            {
                SmtpClient client = GetSmtpClient();
                client.Send(message);
            }
    
            #region Properties
    
            public string From { get; set; }
            public PatternLayout FromProperty { get; set; }
    
            public string To { get; set; }
            public PatternLayout ToProperty { get; set; }
    
            public string Cc { get; set; }
            public PatternLayout CcProperty { get; set; }
    
            public string BCc { get; set; }
            public PatternLayout BccProperty { get; set; }
    
            public string  Subject { get; set; }
            public PatternLayout subjectProperty { get; set; }
    
            public string SmtpHost { get; set; }
            #endregion Properties
    
            #region Override implementation of AppenderSkeleton
    
            override protected void Append(LoggingEvent loggingEvent)
            {
                StringWriter writer = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
    
                string t = Layout.Header;
                if (t != null)
                {
                    writer.Write(t);
                }
    
                // Render the event and append the text to the buffer
                RenderLoggingEvent(writer, loggingEvent);
    
                t = Layout.Footer;
                if (t != null)
                {
                    writer.Write(t);
                }
    
                string mailMessageBody = writer.ToString();
    
                //MailMessage mailMessage = new MailMessage();
                //mailMessage.Body = writer.ToString();
                //mailMessage.From = From;
                //mailMessage.To = m_to;
                string mailMessageSubject;
                if (subjectProperty == null)
                {
                    mailMessageSubject = Subject;
                }
                else
                {
                    var subjectWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
                    subjectProperty.Format(subjectWriter, loggingEvent);
                    mailMessageSubject = subjectWriter.ToString();
                }
    
                if (mailMessageSubject.Contains("null"))
                {
                    mailMessageSubject = Subject;
                }
    
                string mailMessageTo;
                if (ToProperty == null)
                {
                    mailMessageTo = To;
                }
                else
                {
                    var subjectWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
                    ToProperty.Format(subjectWriter, loggingEvent);
                    mailMessageTo = subjectWriter.ToString();
                }
    
                if (mailMessageTo.Contains("null"))
                {
                    mailMessageTo = To;
                }
    
    
                string mailMessageCC;
                if (CcProperty== null)
                {
                    mailMessageCC = Cc;
                }
                else
                {
                    StringWriter subjectWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
                    CcProperty.Format(subjectWriter, loggingEvent);
                    mailMessageCC = subjectWriter.ToString();
                }
    
                if (mailMessageCC.Contains("null"))
                {
                    mailMessageCC = Cc;
                }
    
                string mailMessageBcc;
                if (BccProperty== null)
                {
                    mailMessageBcc = BCc;
                }
                else
                {
                    StringWriter subjectWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
                    BccProperty.Format(subjectWriter, loggingEvent);
                    mailMessageBcc = subjectWriter.ToString();
                }
    
                if (mailMessageBcc.Contains("null"))
                {
                    mailMessageBcc = BCc;
                }
    
                Send(From, mailMessageTo, mailMessageCC, mailMessageBcc,mailMessageSubject, mailMessageBody);
            }
    
            override protected bool RequiresLayout
            {
                get { return true; }
            }
    
            #endregion // Override implementation of AppenderSkeleton
        }
    }
