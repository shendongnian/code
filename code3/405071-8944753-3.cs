        public FormatterResolver _formatResolver;
        public void RegisterFormatResolvers()
        {
            _formatResolver = new FormatterResolver();
            _formatResolver.RegisterFormatter(new BoolPropertyFormatter());
            _formatResolver.RegisterFormatter(new DateTimePropertyFormatter());
            //...etc
        }
