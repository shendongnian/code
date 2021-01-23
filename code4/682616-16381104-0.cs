    public partial class Form1 : Form {
      public Form1() {
        InitializeComponent();
      }
      int c = 0;
      private List<TextBox _lstTextBoxList;
      public List<TextBox> lstTextBoxList {
        get { 
          if(_lstTextBoxList == null) {
            _lstTextBoxList = ViewState["lstTextBoxList"] as List<TextBox>;
          }
          return _lstTextBoxList; 
        }
        set { ViewState["lstTextBoxList"] = _lstTextBoxList = value; }
      }
   
   
      private void button1_Click(object sender, EventArgs e) {
        TextBox txtRun = new TextBox();
        txtRun.Name = "txtDynamic" + c++;
        txtRun.Location = new System.Drawing.Point(20, 18 + (20 * c));
        txtRun.Size = new System.Drawing.Size(200,15);
        this.Controls.Add(txtRun);
        lstTextBoxList.Add(txtRun);
      }
      private void button2_Click(object sender, EventArgs e) {
        // Not sure of your goal here:
        List<string> tilelocation = List<string>();
        tilelocation.Add(lstTextBoxList[lstTextBoxList.Count - 1]);
        // I would assume you wanted this:
        List<string> strValues = lstTextBoxList.Select<TextBox,string>(t =>   t.Text).ToList();
      }
 }
