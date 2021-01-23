            Document _document = new Document();
            _document.Title = "PdfDigitalSignature - Sample";
            _document.Author = "dbAutoTrack Ltd, USA";
            _document.Creator = "dbAutoTrack.PDFWriter";
            PDFDigitalSignature digitalSignature = new PDFDigitalSignature();
            //  digitalSignature.X509Certificate = new X509Certificate2(MapPath("../data/DigitalSignature.pfx"), "password", X509KeyStorageFlags.MachineKeySet |X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable););
            string executingFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var digitalsignaturefilepath = "E:\\wwwroot\\NaveenWindowsAppFile\\WindowsFormsApplication1\\digitalsignaturefile\\DigitalSignature.pfx";
            digitalSignature.X509Certificate = new X509Certificate2(digitalsignaturefilepath, "password", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            digitalSignature.Date = DateTime.Now;
            digitalSignature.Location = "Location ";
            digitalSignature.Reason = "Reason ";
            digitalSignature.ContactInfo = "Convert Digital Code by Cstech";
            digitalSignature.DetachSignature = false;
            digitalSignature.RootTrusted = false;
            _document.DigitalSignature = digitalSignature;
            //password protection code//
            SecurityManager _securityManager = new SecurityManager();
            _securityManager.Encryption = Encryption.Use128BitKey;
            _securityManager.OwnerPassword = filepass;
            _securityManager.UserPassword = filepass;
            _securityManager.AllowCopy = true;
            _securityManager.AllowEdit = true;
            //end//
            //Assign SecurityManager to the Document.
            _document.SecurityManager = _securityManager;
            PDFFont _font1 = new PDFFont(StandardFonts.TimesRoman, FontStyle.Regular);
            dbAutoTrack.PDFWriter.Page page1 = new dbAutoTrack.PDFWriter.Page(PageSize.A4);
            PDFGraphics graphics1 = page1.Graphics;
            PdfSignatureField signatureField = graphics1.AddDigitalSignature("name", new RectangleF(50, 50, 150, 75), _font1, 8f);
            signatureField.DigitalSignature = digitalSignature;
            _document.Pages.Add(page1);
            using (FileStream outFile = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
            {
                _document.Generate(outFile);
            }
        }
