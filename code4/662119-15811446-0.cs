    myXmlTextWriter2.WriteStartElement("Account");
    myXmlTextWriter2.WriteAttributeString("nr", AccountNumber.ToString());
    myXmlTextWriter2.WriteAttributeString("name", Name);
    
    double summ=0;
    foreach (AccountRecord ar in kp)
    {
     myXmlTextWriter2.WriteStartElement("Accounting");
     myXmlTextWriter2.WriteElementString("income", ar.Amount.ToString());
     myXmlTextWriter2.WriteEndElement();
     summ += ar.Amount;
     }
    
    myXmlTextWriter2.WriteElementString("summincome", summ.ToString());
    myXmlTextWriter2.WriteEndElement();
