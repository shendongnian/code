    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            BindingListInvoked<Name> names;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                names = new BindingListInvoked<Name>(dataGridView1);
    
                dataGridView1.DataSource = names;
    
                new Thread(() => names.Add(new Name() { FirstName = "Larry", LastName = "Lan" })).Start();
                new Thread(() => names.Add(new Name() { FirstName = "Jessie", LastName = "Feng" })).Start();
            }
        }
    
        public class BindingListInvoked<T> : BindingList<T>
        {
            public BindingListInvoked() { }
    
            private ISynchronizeInvoke _invoke;
            public BindingListInvoked(ISynchronizeInvoke invoke) { _invoke = invoke; }
            public BindingListInvoked(IList<T> items) { this.DataSource = items; }
            delegate void ListChangedDelegate(ListChangedEventArgs e);
    
            protected override void OnListChanged(ListChangedEventArgs e)
            {
    
                if ((_invoke != null) && (_invoke.InvokeRequired))
                {
                    IAsyncResult ar = _invoke.BeginInvoke(new ListChangedDelegate(base.OnListChanged), new object[] { e });
                }
                else
                {
                    base.OnListChanged(e);
                }
            }
            public IList<T> DataSource
            {
                get
                {
                    return this;
                }
                set
                {
                    if (value != null)
                    {
                        this.ClearItems();
                        RaiseListChangedEvents = false;
    
                        foreach (T item in value)
                        {
                            this.Add(item);
                        }
                        RaiseListChangedEvents = true;
                        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                    }
                }
            }
        }
    
        public class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
