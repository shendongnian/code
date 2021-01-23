     string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
    txtSearch.Attributes.Add("onkeyup", "setTimeout('__doPostBack(\'" + txtSearch.ClientID.Replace("_", "$") + "\',\'\')', 0);");
            if (!IsPostBack)
            {
                Gridview1.DataBind();
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
             SearchString = txtSearch.Text;
        }
        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtSearch.Text.ToString();
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the
            //delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
            // Set the RegExp to null.
            RegExp = null;
        }
        public string ReplaceKeyWords(Match m)
        {
            return "<span class=highlight>" + m.Value + "</span>";
        }
