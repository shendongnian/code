    Style style = new Style(typeof(ComboBox));
    var d = new DataTemplate();
                
    MultiBinding mb = new MultiBinding();
    mb.StringFormat = "{0} {1} Mitglied(er)";
    mb.Bindings.Add(new Binding("Name"));
    mb.Bindings.Add(new Binding("MemberCount"));
    
    FrameworkElementFactory textElement = new FrameworkElementFactory(typeof(TextBlock));
    textElement.SetBinding(TextBlock.TextProperty, mb);
    d.VisualTree = textElement;
    
    style.Setters.Add(new Setter(ComboBox.ItemTemplateProperty, d));
    this.Resources.Add("ComboBox_EntityCreation_GroupSelect_Style", style);
