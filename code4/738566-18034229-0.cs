    public class Kid : IEditableObject, INotifyPropertyChanged
        {
            public int? Id
            {
                get { return _id; }
                set
                {
                    this._id = value;
                    if (PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                }
            }
            public string Name
            {
                get { return _name; }
                set
                {
                    this._name = value;
                    if (PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
            public Person Parent { get; set; }
            public Kid()
            {
                this.Id = 12345;
                this.Name = "kidname";
            }
            public Kid(int id, string name = "kidname")
            {
                this.Id = 12345;
                this.Name = name;
            }
            #region IEditableObject Members
            public void BeginEdit()
            {
                if (isEdit) return;
                isEdit = true;
                this.backup = this.MemberwiseClone() as Kid;
            }
            public void CancelEdit()
            {
                if (!this.isEdit)
                    return;
                isEdit = false;
                this.Id = backup.Id;
            }
            public void EndEdit()
            {
                if (this.isEdit == false)
                    return;
                this.isEdit = false;
                this.backup = null;
            }
            #endregion
            private int? _id;
            private string _name;
            private bool isEdit;
            private Kid backup;
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
        }
