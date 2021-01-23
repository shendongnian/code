    public class Project {
        public string Name { get; set; }
        private User _leadUser;
        public User LeadUser {
            get { return _leadUser; }
            set {
                if (_leadUser != value) {
                    if (_leadUser != null) {
                        _leadUser.Projects.Remove(this);
                        if (!value.Projects.Contains(this)) {
                            value.Projects.Add(this);
                        }
                    }
                    _leadUser = value;
                }
            }
        }
    }
