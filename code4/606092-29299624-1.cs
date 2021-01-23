    public partial class RibbonSample
    {
      private void RibbonSample_Load(object sender, RibbonUIEventArgs e)
      {
        // Initialise log4net 
      }
      //Adding items in menu from DB
      public RibbonSample()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            try
            {
                System.Data.DataTable dt = new DataAcces().GetData();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RibbonButton Field = this.Factory.CreateRibbonButton();
                        Field.Label = dt.Rows[i][1].ToString();
                        Field.Tag = i;
                        Field.ControlSize =
                            Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
                        Field.Click += Field_Click;
                        menu1.Items.Add(Field);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No Fields are available in database");
                }
            }
            catch (Exception exception)
            {
                //thrw exception
            }
        }
    //Select menu item text in word 
    void Field_Click(object sender, RibbonControlEventArgs e)
    {
        try
        {
            Microsoft.Office.Interop.Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            currentRange.Text = (sender as RibbonButton).Label;
        }
        catch (Exception exception)
        {
            log.Error(friendlyErrorMessage + " Field_Click Details:" + exception.Message, exception);
        }
      }
    }
