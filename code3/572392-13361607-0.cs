    public class MustHaveOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
    [MustHaveOneElementAttribute (ErrorMessage = "At least a task is required")]
    public List<Person> TaskDescriptions { get; private set; }
