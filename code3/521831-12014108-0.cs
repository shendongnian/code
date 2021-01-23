    string foo = @"<bogus><siteMapNode title='Our Clients' url='~/OurClients'>
                    <siteMapNode title='Website Portfolio' url='~/OurClients/Portfolio' />
                    <siteMapNode title='Testimonials' url='~/OurClients/Testimonials' />
                    </siteMapNode>
    
                <siteMapNode title='Contact' url='~/Contact' />
                <siteMapNode title='' url='~/Pharmacy' />
                <siteMapNode url='~/ClinicWebsiteDevelopment' />
                <siteMapNode url='~/HospitalWebsiteDevelopment' /></bogus>";
    
    
    XDocument doc = XDocument.Parse(foo);
    
    var elements = doc.Root.Elements("siteMapNode");
    foreach (var elem in elements) {
        if (elem.Attribute("title") == null)
            Console.WriteLine("This one doesn't have the attribute!");
    }
