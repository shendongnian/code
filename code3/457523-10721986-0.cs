    PageResultRequestControl pageRequestControl = new PageResultRequestControl(500);
    
    SearchOptionsControl soc = new SearchOptionsControl(System.DirectoryServices.Protocols.SearchOption.DomainScope);
    
    request.Controls.Add(pageRequestControl);
    request.Controls.Add(soc);
