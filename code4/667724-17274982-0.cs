    Asn1OctetString outer =(Asn1OctetString)Asn1Object.FromByteArray(b_signature);
    byte[] inner = outer.GetOctets();
    
    Console.WriteLine(Asn1Dump.DumpAsString(outer));
    Console.WriteLine(Asn1Dump.DumpAsString(Asn1Object.FromByteArray(inner)));
