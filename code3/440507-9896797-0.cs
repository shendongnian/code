    public interface IEditatble
    {
        void SetValue(Control sender, DependencyProperty property);
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class EditableAttribute : Attribute, IEditatble
    {
        public EditableAttribute(bool isEditable)
        {
            this.ReadOnly = !isEditable;
        }
        public virtual bool ReadOnly { get; set; }
        public void SetValue(System.Windows.Controls.Control sender, System.Windows.DependencyProperty property)
        {
            sender.SetValue(property, this.ReadOnly);
        }
    }
