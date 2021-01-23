    public class Task : DomainBase
    {
        public virtual ICollection<Subtask> Subtasks { get; set; }
        [Display(Name = "Subtask(s) Total Cost")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        //calculated property
        public virtual double TotalSubTaskCost
        {
            get
            {
                if (Subtasks == null)
                    return 0;
                if (!Subtasks.Any())
                    return 0;
                double it = Subtasks.Where(a => a != null).
                    Aggregate<Subtask, double>
                        (0, (current, a) => current + a.TotalCost);
                return it;
            }
        }
     }
