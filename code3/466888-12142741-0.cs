    <Page>
        <Viewbox Stretch="Fill" Margin="15">
            <Frame Height="800" Width="1280" Content="{Binding SlideFrame}"/>
        </Viewbox>
    </Page>
    using System.Windows.Controls;
    private Page _slideFrame;
    // Property
    public Page SlideFrame
    {
        get { return _slideFrame; }
        set
        {
            _slideFrame = value;
            NotifyPropertyChanged("SlideFrame");
        }
    }
