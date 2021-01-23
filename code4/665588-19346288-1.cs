    static string TokenRFC2616(string key)
    {
        const string separators = "()|<>@,;:\\\"/[]?={} ";
    	var chars = from ch in key.Normalize(NormalizationForm.FormD)
                where CharUnicodeInfo.GetUnicodeCategory(ch) 
                         != UnicodeCategory.NonSpacingMark &&
    		          separators.IndexOf(ch)==-1
    		    select ch;
    	return String.Concat(chars);
    }
    string cookiekey = TokenRFC2616(
           "Infoscreen_Anzeigeeinstellungen_Ausgewählte_Abteilung");
    if (!Page.IsPostBack)
    { 
       Response.Cookies[cookieKey].Value =  ausgewählte_Abteilung.ToString(); 
    }
    else
    { 
        ausgewählte_Abteilung = Request.Cookies[cookieKey].Value; 
    }
