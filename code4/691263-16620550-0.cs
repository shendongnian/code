    class Details
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
          get { return this.FirstName + " " + this.LastName; }
          // You could also use a stored value if you think concatenating
          // strings will be a performance problem, but I think that's unlikely
        }
    }
