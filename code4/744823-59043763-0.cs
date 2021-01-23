      private FontFamily GetFontFamily(string name)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            var path = Server.MapPath("~/Static/webfont/" + name + ".ttf");
            pfc.AddFontFile(path);
    **while (pfc.FontFamilies != null && pfc.Families.Length > 0 && (pfc.FontFamilies[0] as FontFamily).Name != "YourFontName")
            {
                pfc.Dispose();
                pfc = new PrivateFontCollection();
                GetFontFamily();
            }
            return pfc.Families[0];
        }
