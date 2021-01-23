        static string clipHTML { get; set; } 
    
        public yourclass()
        {
        
        clipHTML = Clipboard.GetText(TextDataFormat.Html);
        
        }
