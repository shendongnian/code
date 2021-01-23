    public partial class _Default : ThemePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            var currentTheme = ThemeSwitcher.GetCurrentTheme();
            foreach (var theme in ThemeSwitcher.ListThemes())
            {
                var item = new ListItem(theme);
                item.Selected = theme == currentTheme;
                ddlThemes.Items.Add(item);
            }
        }
        protected void ddlThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThemeSwitcher.SaveCurrentTheme(ddlThemes.SelectedItem.Value);
            Response.Redirect("~/default.aspx");
        }       
    }
