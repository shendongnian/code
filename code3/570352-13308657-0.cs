    public string Redirect(string Team)
    {
        var hostName = "http://localhost/test/testpage.aspx?";
        var team = "&Team=" + Team;
        var filterUrl = hostname + Team;
        return filterUrl;
    }
    function RedirectSuccess(data) {
            if (data != undefined) {
                window.location = data;          
                 }
        }
