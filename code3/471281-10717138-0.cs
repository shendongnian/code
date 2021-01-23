    using System.IO;
    
    string filename = Path.GetFileName(filepath); // returns "1-AXJUHC_65927302.pdf"
    string id = Path.GetFileNameWithoutExtension(filename.Replace(".", "~").Replace("_", ".")).Replace("~", "."); // for "1-AXJUHC_65927302.pdf", returns "1-AXJUHC"
    string fileextension = Path.GetExtension(filename).Substring(1);// returns "pdf"
