            int tempInstanceCount = instanceCount;
            vartable2[instanceCount.ToString()] = new Thread(delegate()
            {
                using (var message = new MailMessage(senderAdrress, toAddress)
                {
                    Subject = strSubject,
                    Body = strBody
                })
                {
                    {
                        ((SmtpClient)vartable[tempInstanceCount.ToString()]).Send(message);
                    }
                }
            });
