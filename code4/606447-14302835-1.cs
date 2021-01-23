    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Linq;
    namespace ProiectBDD
    {
        public partial class AdaugaIntrebari : UserControl
        {
            private string connstring;
            private IEnumerator<DataRow> _enumerator;
            public string Connstring
            {
                get { return connstring; }
                set { connstring = value; }
            }
            public AdaugaIntrebari(string p_connstring)
            {
                connstring = p_connstring;
                InitializeComponent();
                IncarcaCategorii();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (_enumerator == null) return;
                if (enumerator.MoveNext())
                {
                    label1.Text = _enumerator.Current.Categorie;
                }
            }
            public void IncarcaCategorii()
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                var q = from a in dc.GetTable<Categorii>()
                        select a;
                _enumerator = q.AsEnumerable().GetEnumerator();
            }
        }
    }
