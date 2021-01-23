    string html = string.Empty; 
    do
    {
        html = new StreamReader(response3.GetResponseStream(),
                                       Encoding.UTF8).ReadToEnd();
        if (html.Contains("link-censored"))
        {
            log("[!] Banned link\r\n");
            return -2; // delete url from txt
        }
        else if (html.Contains("data-with-image"))
        {
            log("[+] Add link\r\n");
        }
        else
        {
            log("[?] Smthng wrong with link\r\n");
            return -2; //-3
        }
    }
    while (html.Contains("data-with-image"));
