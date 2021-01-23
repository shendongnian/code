    public partial class Form1 : Form
    {
        private readonly List<Targets> _targetses;
        private BindingList<Targets> _fiList;
        public Form1()
        {
            InitializeComponent();
            this._targetses = new List<Targets>();
            this._targetses.Add(new Targets("Sample"));
            this._targetses.Add(new Targets("Sample"));
            this._targetses.Add(new Targets("Sample"));
            this._targetses.Add(new Targets("Sample") {ShouldDisplay = false});
            this.bindingSource1.DataSource = this.FilteredList;
            this.lookUpEdit1.Properties.DataSource = this.bindingSource1;
            this.bindingSource1.ListChanged += BindingSource1OnListChanged;
            this._targetses[1].ShouldDisplay = false;
        }
        public BindingList<Targets> FilteredList
        {
            get
            {
                return this._fiList ??
                       (this._fiList = new BindingList<Targets>(this._targetses.Where(x => x.ShouldDisplay).ToList()));
            }
        }
        private void BindingSource1OnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            this._fiList.Clear();
            foreach (Targets t in this._targetses.Where(x => x.ShouldDisplay)) { this._fiList.Add(t); }
        }
        #region Nested type: Targets
        public class Targets : INotifyPropertyChanged
        {
            private bool _bShouldDisplay;
            private string _sTarget;
            public Targets(string target)
            {
                Target = target;
                ShouldDisplay = true;
            }
            public string Target
            {
                get { return this._sTarget; }
                set
                {
                    if (this._sTarget == value)
                        return;
                    this._sTarget = value;
                    this.OnPropertyChanged();
                }
            }
            public bool ShouldDisplay
            {
                get { return this._bShouldDisplay; }
                set
                {
                    if (this._bShouldDisplay == value)
                        return;
                    this._bShouldDisplay = value;
                    this.OnPropertyChanged();
                }
            }
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            #endregion
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
