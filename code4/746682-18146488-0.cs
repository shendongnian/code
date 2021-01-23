    public class BasePage: Page
    { 
	  public BasePage()
	  {
		//
		// TODO: Add constructor logic here
		//
    
      }
      protected override void OnPreInit(EventArgs e)
      {
        Page.Theme = "Default";
        base.OnPreInit(e);
      }
      protected override void OnInit(EventArgs e)
      {
        base.OnInit(e);
      }
    protected override void InitializeCulture()
    {
        string CurrencySymbol = "";
        string lang = string.Empty;
        HttpCookie cookie = Request.Cookies["ddl_LanguageSwitcher"];
        if (cookie != null && cookie.Value != null)
        {
            lang = cookie.Value;
            CultureInfo eg = CultureInfo.CreateSpecificCulture(lang);
            IsArabic = (lang.IndexOf("ar-") >= 0);
            if (IsArabic)
            {
                CurrencySymbol = "جم";
            }
            else
            {
                CurrencySymbol = "EGP";
            }
            DateTimeFormatInfo di = new DateTimeFormatInfo();
            di.FullDateTimePattern = "dd/MM/yyyy HH:mm:ss";
            di.ShortDatePattern = "dd/MM/yyyy";
            eg.DateTimeFormat = di;
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencySymbol = CurrencySymbol;
            ni.CurrencyDecimalDigits = 2;
            ni.NumberDecimalDigits = 2;
            //ni.CurrencyGroupSeparator = "-";
            ni.NumberGroupSeparator = "";
            eg.NumberFormat = ni;
            System.Threading.Thread.CurrentThread.CurrentUICulture = eg;
            System.Threading.Thread.CurrentThread.CurrentCulture = eg;
            _culture = Request.Cookies["ddl_LanguageSwitcher"].Value;
        }
        else
        {
            if (string.IsNullOrEmpty(lang)) lang = BL.Settings.DefaultLanguage;
            CultureInfo eg = CultureInfo.CreateSpecificCulture(lang);
            IsArabic = (lang.IndexOf("ar-") >= 0);
            if (IsArabic)
            {
                CurrencySymbol = "جم";
                //eg.NumberFormat.CurrencySymbol = "جم";
            }
            else
            {
                CurrencySymbol = "EGP";
                //eg.NumberFormat.CurrencySymbol = "EGP";
            }
            DateTimeFormatInfo di = new DateTimeFormatInfo();
            di.FullDateTimePattern = "dd/MM/yyyy HH:mm:ss";
            di.ShortDatePattern = "dd/MM/yyyy";
            eg.DateTimeFormat = di;
            NumberFormatInfo ni = new NumberFormatInfo();
            ni.CurrencySymbol = CurrencySymbol;
            ni.CurrencyDecimalDigits = 2;
            ni.NumberDecimalDigits = 2;
            //ni.CurrencyGroupSeparator = "-";
            ni.NumberGroupSeparator = "";
            eg.NumberFormat = ni;
            System.Threading.Thread.CurrentThread.CurrentUICulture = eg;
            System.Threading.Thread.CurrentThread.CurrentCulture = eg;
            HttpCookie cookie2 = new HttpCookie("ddl_LanguageSwitcher");
            cookie2.Value = lang;
            Response.SetCookie(cookie2);
            _culture = "ar-EG";
        }
        base.InitializeCulture();
    }
    }
