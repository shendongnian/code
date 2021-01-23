    if (!mandatoryusers.All(i => mandatory.Contains(i.CertificateValue) 
                            || i.Uid == item.Uid))
    {
         mandatoryusers.RemoveAll(i => i.Uid == item.Uid);
    }
