    using System.Windows.Forms;
    using Demo.Model;
    using System.Threading;
    namespace Demo.Controls
    {
        public partial class OrderView : UserControl, IDisposable
        {
            private Order _order;
            private Timer poller;
            public Order Order
            {
                get { return _order; }
                set
                {
                    _order = value;
                    UpdateView();
                }
            }
            private void UpdateView()
            {
                if (_order == null) return;
                IdLBL.Text = string.Format("ID: {0}", _order.Id);
                DateLBL.Text = string.Format("Date: {0}", _order.Date);
                ItemsDGV.DataSource = _order.Items;
            }
            public OrderView()
            {
                InitializeComponent();
                _poller = new Timer(CheckUpdate, null, timeSpan, timeSpan);
            }
            private void CheckUpdate(Object state)
            {
                //Do update check and update Order if it has changed
            }
            public void Dispose()
            {
                if (_poller != null)
                {
                    _poller.Dispose();
                }
            }
        }
    }
