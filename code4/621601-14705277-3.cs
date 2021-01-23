        // Get Information
        var c = (X509Certificate2)certificate;
        foreach (var e in c.Extensions)
        {
            Console.WriteLine("Validating OId :'{0}', friendly Name:'{1}'", e.Oid.Value, e.Oid.FriendlyName);
            if (_extendedValidationOids.Contains(e.Oid.Value))
            {
                Console.WriteLine("Certificate is of type 'Extended Validation'");
            }
        }
