        public Group Group
        {
            get { return _board.Entity; }
            set
            {
                if (SetProperty(ref _group, value) != null)
                {
                    _groupId = value.GroupId;
                }
            }
        }
