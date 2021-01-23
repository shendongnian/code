                        SmtpClient smtpClient = new SmtpClient();
                        
                        String smtpDetails =
                            @"
                            DeliveryMethod = {0},
                            Host = {1},
                            PickupDirectoryLocation = {2},
                            Port = {3},
                            TargetName = {4},
                            UseDefaultCredentials = {5}";
    
                        Console.WriteLine(smtpDetails,
                            smtpClient.DeliveryMethod.ToString(),
                            smtpClient.Host,
                            smtpClient.PickupDirectoryLocation == null ? "Not Set" : smtpClient.PickupDirectoryLocation.ToString(),
                            smtpClient.Port,
                            smtpClient.TargetName,
                            smtpClient.UseDefaultCredentials.ToString)                            );
