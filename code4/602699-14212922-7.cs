        [Required(ErrorMessage = "DCNotes is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,5}$", ErrorMessage = "DCNotes must contain no more then 5 characters")] //You can change the length of the property to meet the DCNotes needs
        public string DCNotes
        {
            get { return _DCNotes; }
            set
            {
                if (_DCNotes == value)
                    return;
                _DCNotes = value;
                OnPropertyChanged("DCNotes");
            }
        }
