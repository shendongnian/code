    <WrapPanel>
            <ContentControl Content="{Binding Content}"/>
        </WrapPanel>
      public string Content
        {
            get { 
                   return _content;
                }
            set { 
                    _content = value;
                    NotifyChange("Content"); 
                }
        
        }
        public ICommand ButtonCommand
        {
            get 
            {
                Content = "your content that you want to bind";
                return somecommandObject;
            }
        }
