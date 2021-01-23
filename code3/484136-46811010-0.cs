    // create the font we'll use
    var fNormal = FontFactory.GetFont("Helvetica", 10f);
    fNormal.SetColor(0, 0, 0);
    
    // add phrase containing link
    var pFooter = new Phrase();
    
    // add phrase to this containing text only
    var footerStart = new Phrase("Visit ");
    footerStart.Font = fNormal;
    pFooter.Add(footerStart); 
    
    // now create anchor and add with different font
    string wolSiteUrl = "http://www.whateveryoulike.com";
    Anchor wolWebSiteLink = new Anchor(wolSiteUrl, fNormal);
    wolWebSiteLink.Reference = wolSiteUrl;
    wolWebSiteLink.Font = fNormal;
    wolWebSiteLink.Font.SetColor(242, 132, 0);
    pFooter.Add(wolWebSiteLink);
    
    // add text to go after this link
    var footerEnd = new Phrase(" to view these results online.");
    footerEnd.Font = fNormal;
    pFooter.Add(footerEnd);
    var paraFooter = new Paragraph(pFooter);
    
    // add the phrase we've built up containing lots of little phrases to document
    // (assume you have one of these ...)
    doc.Add(paraFooter);
