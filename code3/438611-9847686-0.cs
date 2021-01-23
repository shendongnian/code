     public class ProgramViwer : Form{
      public ProgramViwer()
      {
           InitializeComponent();
           Load += new EventHandler(ProgramViwer_Load);
      }
      private void ProgramViwer_Load(object sender, System.EventArgs e)
      {
           formPanel.Controls.Clear();
           formPanel.Controls.Add(wel);
      }
    }
