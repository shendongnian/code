    public enum ReportTemplate
    {
     [Description("Top view")]
     Top_view=1,
     [Description("Section view")]
     Section_view=2
    }
    ComboBoxEditSettings.ItemsSource = EnumHelper.GetAllValuesAndDescriptions(new
    List<ReportTemplate> { ReportTemplate.Top_view, ReportTemplate.Section_view });
