    private List<Question> questions;
    public partial class GroupExmStart : Form
     {
       string[] randomQsn = new string[totQsn + 1];   //totQsn is the total number of question  for e.g.10     
       public GroupExmStart(string GroupName, string DurationID)
        {
            InitializeComponent();
            this.GrpID=GroupName;
            TopiID=db.GetTopicIDForGroup(GrpID);
    
            string[] conf = db.GetConfiguration(Convert.ToInt16(DurationID)).Split('|');            
    
            Question qsn = new Question();
            
            /// THIS IS MODIFIED //
            questions = qsn.Foo(TopiID, conf);
            int z = Quiz(questions);
    
            totQsn = Convert.ToInt16(conf[0]);            
            for (int kk = 1; kk <= totQsn; kk++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = kk.ToString();
                listView1.Items.Add(lvi);
            }
            randomQsn = new string[totQsn + 1]; 
            timer1.Interval = 1000; //1000ms = 1sec
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
