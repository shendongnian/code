    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    
     class MailSender
        {
            public static int CreateMessageMdp(String destination,String mdp)
            {
                try
                {
                    var client = new SmtpClient("smtp.domain.com", 587)
                    {
                        Credentials = new NetworkCredential("appgestionali@domain.com", "password"),
                        EnableSsl = true
                    };
                    DateTime localDate = DateTime.Now;
                    string body = "Suite à votre demande de mot de passe le " + localDate.ToString("F") + "\n on vous envoi votre mot de passe est :" + mdp;
                    client.Send("appgestionali@domain.com", destination, "Information", body);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(""+ ex.GetBaseException());
                    return -1;
                }
                return 0;
            }
        }
    }
