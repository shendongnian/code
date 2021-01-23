    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CustomCheckBoxListRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            var list = value as IEnumerable<CheckBoxViewModel>;
            if (list != null && list.GetEnumerator().MoveNext())
            {
                foreach (var item in list)
                {
                    if (item.Checked)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
