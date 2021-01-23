            WebClient wb = new WebClient();
            var data = new NameValueCollection();
            data["publicationID"] = "6dce3366"; //Netto ID
            data["selectedPages"] = "all";
            byte[] responsebytes = wb.UploadValues("http://viewer.zmags.com/services/DownloadPDF", "POST", data);
            System.IO.File.WriteAllBytes(@"C:\Tilbudsavis.pdf", responsebytes);
