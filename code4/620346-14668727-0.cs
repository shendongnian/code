        class VM : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public ObservableCollection<SpecialPriceRow> _SpecialPriceRows = new ObservableCollection<SpecialPriceRow>();
            private int _Original = 0;
            private int _Added = 0;
            private int _ToDelete = 0;
            private int _Edited = 0;
            public VM()
            {
                PropertyChanged = new PropertyChangedEventHandler(VM_PropertyChanged);
                //The following lines in the constructor just initialize the SpecialPriceRows.
                //The important thing to take away from this is setting the PropertyChangedEventHandler to point to the UpdateStatuses() function.
                for (int i = 0; i < 12; i++)
                {
                    SpecialPriceRow s = new SpecialPriceRow();
                    s.PropertyChanged += new PropertyChangedEventHandler(SpecialPriceRow_PropertyChanged);
                    SpecialPriceRows.Add(s);
                }
                for (int j = 0; j < 12; j+=2)
                    SpecialPriceRows[j].Price = 20;
            }
            private void VM_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
            }
            private void SpecialPriceRow_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Status")
                    UpdateStatuses();
            }
            public ObservableCollection<SpecialPriceRow> SpecialPriceRows
            {
                get
                {
                    return _SpecialPriceRows;
                }
            }
            private void UpdateStatuses()
            {
                int original = 0, added = 0, todelete = 0, edited = 0;
                foreach (SpecialPriceRow SPR in SpecialPriceRows)
                {
                    switch (SPR.Status)
                    {
                        case SpecialPriceRow.ChangeStatus.Original:
                            original++;
                            break;
                        case SpecialPriceRow.ChangeStatus.Added:
                            added++;
                            break;
                        case SpecialPriceRow.ChangeStatus.ToDelete:
                            todelete++;
                            break;
                        case SpecialPriceRow.ChangeStatus.Edited:
                            edited++;
                            break;
                        default:
                            break;
                    }
                }
                Original = original;
                Added = added;
                ToDelete = todelete;
                Edited = edited;
            }
            public int Original
            {
                get
                {
                    return _Original;
                }
                set
                {
                    _Original = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Original"));
                }
            }
            public int Added
            {
                get
                {
                    return _Added;
                }
                set
                {
                    _Added = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Added"));
                }
            }
            public int ToDelete
            {
                get
                {
                    return _ToDelete;
                }
                set
                {
                    _ToDelete = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ToDelete"));
                }
            }
            public int Edited
            {
                get
                {
                    return _Edited;
                }
                set
                {
                    _Edited = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Edited"));
                }
            }
        }
