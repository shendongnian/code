    using System.Threading;     // For setting the Localization of the thread to fit
    using System.Globalization; // the of the MS Excel localization, because of the MS bug.
    
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                excelFileName = System.IO.Path.Combine(excelPath, "Ziperty Buy Model for Web 11_11_2011.xlsm");
