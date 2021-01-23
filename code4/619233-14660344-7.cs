        String xaml="some xaml";
        MyData myData=new MyData();
        TextReader textReader = new StringReader(CardContext.Xaml);
        XmlReader xmlReader = XmlReader.Create(textReader);
        //setting DataContext for panel named 'content'
        this.content.DataContext = myData;
        FrameworkElement myContent = (FrameworkElement) XamlReader.Load(xmlReader);
        this.content.Children.Clear();
        this.content.Children.Add(myContent);
        InitMyComponents(this.content);
