    @{
        string x = Model.Node.Aktenzeichen != null &&
                       Model.Node.Aktenkurzbezeichung != null ? " ./. " : "";
        string aktenHeader = Html.Raw(Model.Node.Aktenzeichen + x +
                                      Model.Node.Aktenkurzbezeichung).ToString();    
    }
