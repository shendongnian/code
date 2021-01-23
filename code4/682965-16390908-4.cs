    System.Net.WebClient wc = new System.Net.WebClient();
    byte[] data = wc.UploadValues(
        "http://psykopats.net/loadAion.php",
        new System.Collections.Specialized.NameValueCollection(){
            {"server", "66"},
            {"type", "1"},
            {"player", "299345"}});
    string json = System.Text.Encoding.ASCII.GetString(data);
