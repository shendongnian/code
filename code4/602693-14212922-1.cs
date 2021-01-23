        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,5}$", ErrorMessage = "Title must contain no more then 5 characters")]
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value)
                    return;
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
