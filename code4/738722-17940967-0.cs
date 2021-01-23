    public partial class Form1 : Form {
       public Form1(){
          InitializeComponent();
          dataGridView1.AllowUserToAddRows = false;//if you don't want this, just remove it.
          dataGridView1.DataSource = data;
          Timer t = new Timer(){Interval = 1000};
          t.Tick += UpdateGrid;
          t.Start();
       }     
       private void UpdateGrid(object sender, EventArgs e){
          char c1 = (char)rand.Next(65,97);
          char c2 = (char)rand.Next(65,97);
          data.Add(new Info() {Field1 = c1.ToString(), Field2 = c2.ToString()});
          dataGridView1.FirstDisplayedScrollingRowIndex = data.Count - 1;//This will keep the last added row visible with vertical scrollbar being at bottom.
       }
       BindingList<Info> data = new BindingList<Info>();
       Random rand = new Random();
       //the structure of your data including only 2 fields to test
       public class Info
       {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
       }  
    }
