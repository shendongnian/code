    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using StackOverFlowWinForms.Model;
    namespace StackOverFlowWinForms
    {
    public partial class Form1 : Form
    {
        private BindingList<Traveller> _allTravellers = new BindingList<Traveller>();
        public BindingList<Traveller> allTravellers { get { return _allTravellers; } }
        public Form1()
        {
            InitializeComponent();
            allTravellers.Add(new Traveller("Fred"));
            allTravellers.Add(new Traveller("George"));
            allTravellers.Add(new Traveller("Sam"));
            allTravellers.Add(new Traveller("Mary"));
            this.allTravellersDataGrid.DataSource = allTravellers;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (attendeeName.Text == "")
            { MessageBox.Show("Not all information regarding the attendee entered"); }
            else
            {
                allTravellers.Add(new Traveller(attendeeName.Text));
                allTravellersDataGrid.DataSource = null;
                allTravellersDataGrid.DataSource = allTravellers;
                allTravellersDataGrid.Refresh();
            }
        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (allTravellersDataGrid.CurrentRow != null) 
            {
                Traveller travellerToRemove = (Traveller)allTravellersDataGrid.CurrentRow.DataBoundItem;
                allTravellers.Remove(travellerToRemove);
                allTravellersDataGrid.Refresh();
            }
        }
    }
    }
    using System;
    using System.ComponentModel;
    namespace StackOverFlowWinForms.Model
    {
    public class Traveller 
 
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion 
        private string _attendeeName;
        public string attendeeName 
        { 
            get 
            {
                return _attendeeName; 
            } 
            set 
            {
                _attendeeName = value; 
                NotifyPropertyChanged("attendeeName"); 
            } 
        }
        public Traveller()
        {
            this.attendeeName = "Unknown";
        }
        public Traveller(string name)
        {
            this.attendeeName = name;
        }
    }
    }
