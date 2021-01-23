    public class TabButton : Button
    {
        public static readonly DependencyProperty SelectedTemplateProperty = 
            DependencyProperty.Register("SelectedTemplate", typeof(ControlTemplate), typeof(TabButton));
        public ControlTemplate SelectedTemplate
        {
            get { return base.GetValue(SelectedTemplateProperty) as ControlTemplate; }
            set { base.SetValue(SelectedTemplateProperty, value); }
        }
        public TabButton()
        {
            this.Click += new RoutedEventHandler(TabButton_Click);
        }
        ~TabButton()
        {
            
        }
        public void TabButton_Click(object sender, RoutedEventArgs e)
        {
            ControlTemplate template = (ControlTemplate)this.FindResource("Environmental Template Selected");
            (sender as TabButton).Template = template;
        }
    }
