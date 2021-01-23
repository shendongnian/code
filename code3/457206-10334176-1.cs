    public class ChildForm : Form
    {
       private IMyCommonParent whichMenu
       private bool IsAdminMode;
    
       public ChildForm(IMyCommonParent UnknownParent)
       {
          whichMenu = UnknownParent;
          // then a flag to internally detect if admin mode or not based on
          // the ACTUAL class passed in specifically being the admin parent instance
          IsAdminMode = ( UnknownParent is AdminStartMenu );
    
          // the rest is now generic.
          InitializeComponent();
          EditFunction();
    
          if( whichMenu.Adding )
             BlankForm();
          else if( whichMenu.Editing )
             FillFormVariables();
    
          SaveButton.Text = "Save";
       }
    }
