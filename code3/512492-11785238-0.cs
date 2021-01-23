     public virtual DateTime? DueDate { get; set; }
     public string DueDateString
            {
                get { return DueDate != null ? DueDate.ToString() : string.Empty; }
            }
