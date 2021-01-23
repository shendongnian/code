    public class DocumentDownload : PdfTemplateHandler 
    {
        
        protected override string TemplatePath
        {
            get { return "~/App_Data/PdfTemplates/MyDocument_2011_v1.pdf"; }
        }
    
        protected override void LoadDataInternal()
        {
            
            documentType = Request["docType"] != null ? Request["docType"].ToString() : "";
           
            if (uid.Length < 1)
            {
                Response.Write("Invalid request!");
                Response.End();
            }
            // load data
            
            DownloadFileName = string.Format("MyDocument_{0}_{1}.pdf", 1234, DateTime.Now.ToBinary());
        }
    
        protected override void SetFieldsInternal(iTextSharp.text.pdf.AcroFields acroFields)
        {
            
            //iTextSharp.text.pdf.BaseFont unicode = iTextSharp.text.pdf.BaseFont.createFont(unicodeFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);            
            //var unicodeFont = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.FontFactory.TIMES_ROMAN, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
            acroFields.SetField("txtrNumber", Number.ToString());
            
            acroFields.SetField("cbTaxi", "Yes");
            
        }
    }
    public abstract class PdfTemplateHandler : IHttpHandler
    {
        public virtual bool DownloadAsAttachment
        {
            get
            {
                return true;
            }
        }
    
        protected virtual TimeSpan PdfTemplateCacheDuration
        {
            get
            {
                return TimeSpan.FromMinutes(30);
            }
        }
    
        protected virtual string PdfTemplateCacheKey
        {
            get
            {
                return string.Format("__PDF_Template[{0}]", TemplatePath);
            }
        }
    
        protected string DownloadFileName { get; set; }
    
        protected HttpContext Context { get; private set; }
    
        protected HttpResponse Response { get; private set; }
    
        protected HttpRequest Request { get; private set; }
    
        #region IHttpHandler Members
    
        public bool IsReusable
        {
            get { return false; }
        }
    
        public void ProcessRequest(HttpContext context)
        {
    
            Context = context;
            Response = context.Response;
            Request = context.Request;
    
            try
            {
                LoadDataInternal();
            }
            catch (ThreadAbortException)
            {
                // no-op
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex);
                Response.Write("Error!");
                Response.End();
            }
    
            Response.BufferOutput = true;
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
    
            if (DownloadAsAttachment)
            {
                Response.AddHeader("Content-Disposition", "attachment; filename=" +
                    (string.IsNullOrEmpty(DownloadFileName) ? context.Session.SessionID + ".pdf" : DownloadFileName));
            }
    
            PdfStamper pst = null;
            try
            {
                PdfReader reader = new PdfReader(GetTemplateBytes());
                pst = new PdfStamper(reader, Response.OutputStream);
                var acroFields = pst.AcroFields;
    
                pst.FormFlattening = true;
                pst.FreeTextFlattening = true;
                pst.SetFullCompression();
    
                SetFieldsInternal(acroFields);
                pst.Close();
            }
            finally
            {
                if (pst != null)
                    pst.Close();
            }
        }
    
        #endregion
    
        #region Abstract Members for overriding and providing functionality
    
        protected abstract string TemplatePath { get; }
    
        protected abstract void LoadDataInternal();
    
        protected abstract void SetFieldsInternal(AcroFields acroFields);
    
        #endregion
    
        protected virtual byte[] GetTemplateBytes()
        {
            var data = Context.Cache[PdfTemplateCacheKey] as byte[];
            if (data == null)
            {
                data = File.ReadAllBytes(Context.Server.MapPath(TemplatePath));
                Context.Cache.Insert(PdfTemplateCacheKey, data,
                    null, DateTime.Now.Add(PdfTemplateCacheDuration), Cache.NoSlidingExpiration);
            }
            return data;
        }
    
        protected static string unicode_iso8859(string src)
        {
            Encoding iso = Encoding.GetEncoding("iso8859-2");
            Encoding unicode = Encoding.UTF8;
            byte[] unicodeBytes = unicode.GetBytes(src);
            return iso.GetString(unicodeBytes);
        }
        protected static string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
    
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
    
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
    
    }
