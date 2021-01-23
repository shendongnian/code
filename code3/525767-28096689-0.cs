                // create global configuration object
            GlobalConfig gc = new GlobalConfig();
            // set it up using fluent notation
            gc.SetMargins(new Margins(10, 10, 10, 10))
              .SetDocumentTitle("Test document")
              .SetPaperSize(PaperKind.Letter);
              
            //... etc
            // create converter
            IPechkin pechkin = new SynchronizedPechkin(gc);
            // create document configuration object
            ObjectConfig oc = new ObjectConfig();
            // and set it up using fluent notation too
            oc.SetCreateExternalLinks(false)
              
              .SetLoadImages(false)
              .SetPrintBackground(true)
              .SetLoadImages(true);
            //... etc
            // convert document
            byte[] pdfBuf = pechkin.Convert(oc, html);
