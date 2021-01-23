    private void ImpersonateUsers(ICollection<string> userSmtps)
            {
                if (userSmtps != null)
                    if (userSmtps.Count > 0)
                    {
                        foreach (var userSmtp in userSmtps)
                        {
                            if (_services.ContainsKey(userSmtp)) continue;
                            var newService = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
    
                            try
                            {
                                var serviceCred = ((System.Net.NetworkCredential)(((WebCredentials)(_services.First().Value.Credentials)).Credentials));
                                newService.Credentials = new WebCredentials(serviceCred.UserName, serviceCred.Password, serviceCred.Domain);
                                newService.AutodiscoverUrl(serviceCred.UserName + "@" + serviceCred.Domain, RedirectionUrlValidationCallback);
                                newService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, userSmtp);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                            _services.Add(userSmtp, newService);
                        }
                    }
            }
