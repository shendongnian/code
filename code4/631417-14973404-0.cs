        var patternEmail = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    
        var emailCollection1 = Regex.Matches(piWorkitem.ResponsibleConsultant, patternEmail).Cast<Match>().Union(Regex.Matches(piWorkitem.SupplierConsultant, patternEmail).Cast<Match>());
        foreach (Match mail in emailCollection1.Where(mail => !emailaddresses.Contains(mail.Value.ToString())))
        {
            emailaddresses.Add(mail.Value);
        }
