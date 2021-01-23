    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnVisited_Click(object sender, EventArgs e)
        {
            {
                string[] CityName = {"Columbus", "Bloomington", "Indianapolis",
                "Fort Wayne", "Greensburg", "Gary", "Chicago", "Atlanta", "Las Vegas"};
                string queryCity = txtState.Text;
                int position;
                string city;
                if (CityName.Contains(queryCity))
                {
                    position = Array.IndexOf(CityName, queryCity);
                    city = txtState.Text;
                    txtAnswer.Text = "You have visited" +" " + queryCity + " " + position;
                }
                else
                {
                    txtAnswer.Text = "You have not visited this city yet.";
                }
            }`
