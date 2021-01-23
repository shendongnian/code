        public string ProductDescription { get; set; }
        public string ShortDescription
        {
            get
            {
                var text = ProductDescription;
                if (text.Length > 21)
                {
                    text = text.Remove(19);
                    text += "..";
                }
                return text ;
            }
        }
