    public void ChangeTheme(ControlTheme theme)
    {
        int dic = 2;
        if (theme == ControlTheme.Theme1)
            dic = 1;
        ResourceDictionary rd = new ResourceDictionary();
        rd.Source = new Uri(@"pack://application:,,,/WpfApplication1;component/Dictionary" + dic + ".xaml");
        this.Resources.Clear();
        this.Resources = rd; 
    } 
